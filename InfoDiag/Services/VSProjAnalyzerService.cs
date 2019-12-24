using System;
using System.IO;
using System.Linq;
using System.Xml;
using Entity;
using Repositories.Interfaces;
using Services.Interfaces;
using Services.Models;

namespace Services
{
    public class VSProjAnalyzerService : BaseService, IVSProjAnalyzerService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IInstitutionRepository _institutionRepository;
        private readonly ICourseService _courseService;

        public VSProjAnalyzerService(
            IClientRepository clientRepository,
            IInstitutionRepository institutionRepository,
            ICourseService courseService)
        {
            _clientRepository = clientRepository;
            _institutionRepository = institutionRepository;
            _courseService = courseService;
        }

        public ServiceCallResult<int> Process(string projPath)
        {
            if (!File.Exists(projPath))
            {
                return Error<int>("File doesn't exist");
            }

            var result = ExtractInfo(projPath);

            if (result.Failed)
            {
                return Error<int>(result.Error);
            }

            (string first, string last, string email, string institutionAlias, string courseAlias) = result.Value;

            var institution = _institutionRepository.AllAsQueryable.Where(i => i.Alias == institutionAlias).FirstOrDefault();

            if (institution == null)
            {
                return Error<int>("Institution doesn't exist");
            }

            var client = _clientRepository.AllAsQueryable.Where(c => c.Email == email).FirstOrDefault();

            if (client != null)
            {
                Update(client, first, last);
            }
            else
            {
                client = new Client
                {
                    FirstName = first,
                    LastName = last,
                    Email = email,
                };

                client = _clientRepository.Insert(client);
            }

            if (_courseService.ProcessCourseGroupAlias(courseAlias, client.Id).Failed)
            {
                return Error<int>("An error occured while verifying the course");
            }

            return Success(client.Id);
        }

        private ServiceCallResult<(string first, string last, string email, string institution, string course)> ExtractInfo(string projPath)
        {
            XmlDocument xmlDoc = new XmlDocument();

            xmlDoc.Load(projPath);

            var re = xmlDoc.GetElementsByTagName("PropertyGroup");
            XmlElement requierdElement = null;
            foreach (XmlElement n in re)
            {
                if (n.GetAttribute("Label") == "UserMacros")
                {
                    requierdElement = n;
                    break;
                }
            }

            if (requierdElement == null)
            {
                return Error<(string, string, string, string, string)>("Required element in the .vsproj is missing");
            }

            string first = null;
            string last = null;
            string email = null;
            string institution = null;
            string course = null;

            foreach (XmlElement n in requierdElement.ChildNodes)
            {
                switch (n.Name)
                {
                    case "UserFirtName":
                    case "UserFirstName":
                        first = n.InnerText;
                        break;
                    case "UserLastName":
                        last = n.InnerText;
                        break;
                    case "UserEmail":
                        email = n.InnerText;
                        break;
                    case "InstitutionId":
                        institution = n.InnerText;
                        break;
                    case "Course":
                        course = n.InnerText;
                        break;
                }
            }

            if (first == null || last == null || email == null || institution == null || course == null)
            {
                return Error<(string, string, string, string, string)>("Information is missing in the .vsproj");
            }

            return Success((first, last, email, institution, course));
        }

        private void Update(Client client, string first, string last)
    {
        var hasChanged = false;
        if (client.FirstName != first)
        {
            client.FirstName = first;
            hasChanged = true;
        }

        if (client.LastName != last)
        {
            client.FirstName = last;
            hasChanged = true;
        }

        if (hasChanged)
        {
            _clientRepository.Update(client);
        }
    }
}
}
