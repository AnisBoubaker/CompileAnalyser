using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Constants.Enums;
using Entity.DTO;
using Repositories.Interfaces;
using Services.Interfaces;

namespace Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public ClientService(IClientRepository clientRepository, IUserRepository userRepository, IMapper mapper)
        {
            _clientRepository = clientRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public IEnumerable<ClientDTO> GetAllClients(string userEmail, UserRole userRole)
        {
            var userQuery = _userRepository.AllAsQueryable.Where(u => u.Email == userEmail);
            var baseClientQuery = userQuery.SelectMany(u => u.CourseGroups).SelectMany(cg => cg.CourseGroupClients).Select(cgc => cgc.Client);
            if (userRole != UserRole.Teacher)
            {
                baseClientQuery.Concat(userQuery.SelectMany(u => u.Employees).SelectMany(e => e.CourseGroups).SelectMany(cg => cg.CourseGroupClients).Select(cgc => cgc.Client));
                if (userRole == UserRole.Admin)
                {
                    baseClientQuery.Concat(userQuery.SelectMany(u => u.Employees).SelectMany(u => u.Employees).SelectMany(e => e.CourseGroups).SelectMany(cg => cg.CourseGroupClients).Select(cgc => cgc.Client));
                }
            }

            return _mapper.Map<IEnumerable<ClientDTO>>(baseClientQuery);
        }
    }
}
