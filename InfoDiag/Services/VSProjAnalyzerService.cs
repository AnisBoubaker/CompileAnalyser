using System;
using System.IO;
using System.Linq;
using System.Xml;
using Entity;
using Repositories.Interfaces;
using Services.Interfaces;

namespace Services
{
    public class VSProjAnalyzerService : BaseService, IVSProjAnalyzerService
    {
        private readonly IClientRepository clientRepository;
        private readonly IInstitutionRepository institutionRepository;
        private readonly ICourseService courseService;

        public VSProjAnalyzerService(
            IClientRepository clientRepository,
            IInstitutionRepository institutionRepository,
            ICourseService courseService)
        {
            this.clientRepository = clientRepository;
            this.institutionRepository = institutionRepository;
            this.courseService = courseService;
        }

        public int Process(string projPath)
        {
            if (!File.Exists(projPath))
            {
                return 0;
            }

            (string first, string last, string email, string institutionAlias, string courseAlias) = ExtractInfo(projPath);

            if (email == null)
            {
                return 0;
            }

            var institution = institutionRepository.AllAsQueryable.Where(i => i.Alias == institutionAlias).FirstOrDefault();

            if (institution == null)
            {
                return 0;
            }

            var client = clientRepository.AllAsQueryable.Where(c => c.Email == email).FirstOrDefault();

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

                clientRepository.Insert(client);
            }

            if (courseService.ProcessCourseGroupAlias(courseAlias, client.Id))
            {
                return 0;
            }

            return client.Id;
        }

        private (string first, string last, string email, string institution, string course) ExtractInfo(string projPath)
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
                return (null, null, null, null, null);
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

            return (first, last, email, institution, course);
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
            clientRepository.Update(client);
        }
    }
}
}
