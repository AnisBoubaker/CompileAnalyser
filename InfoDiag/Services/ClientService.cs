using System;
using System.IO;
using System.Linq;
using System.Xml;
using Entity;
using Repositories.Interfaces;
using Services.Interfaces;

namespace Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            this.clientRepository = clientRepository;
        }

        public int FindClientId(string projPath)
        {
            if (!File.Exists(projPath))
            {
                return 0;
            }

            (var first, var last, var email) = ExtractInfo(projPath);

            if (email == null)
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

            return client.Id;
        }

        private (string first, string last, string email) ExtractInfo(string projPath)
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
                return (null, null, null);
            }

            string first = null;
            string last = null;
            string email = null;

            foreach (XmlElement n in requierdElement.ChildNodes)
            {
                // This is from a typo in the template
                if (n.Name == "UserFirtName")
                {
                    first = n.InnerText;
                }
                else if (n.Name == "UserFirstName")
                {
                    first = n.InnerText;
                }
                else if (n.Name == "UserLastName")
                {
                    last = n.InnerText;
                }
                else if (n.Name == "UserEmail")
                {
                    email = n.InnerText;
                }
            }

            return (first, last, email);
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
