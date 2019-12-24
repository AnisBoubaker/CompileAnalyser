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
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public ClientService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public IEnumerable<ClientDTO> GetAllClients(string userEmail)
        {
            return _mapper.Map<IEnumerable<ClientDTO>>(_userRepository.AllAsQueryable.Where(u => u.Email == userEmail).SelectMany(u => u.CourseGroups).SelectMany(cg => cg.Clients));
        }
    }
}
