namespace Services
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using Constants.Enums;
    using Entity.DTO;
    using Microsoft.EntityFrameworkCore;
    using Repositories.Interfaces;
    using Services.Interfaces;

    public class ClientService : IClientService
    {
        private readonly IUserRepository _userRepository;
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;

        public ClientService(IUserRepository userRepository, IClientRepository clientRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _clientRepository = clientRepository;
            _mapper = mapper;
        }

        public IEnumerable<ClientDTO> GetAllClients(string userEmail)
        {
            var cgids = _userRepository.AllAsQueryable
                .Where(u => u.Email == userEmail)
                .SelectMany(u => u.CourseGroupUsers).Select(cg => cg.CourseGroupId);

            var clients = _clientRepository.AllAsQueryable
                .Where(c => c.CourseGroupClients
                .Select(cg => cg.CourseGroupId)
                .Any(cg => cgids.Any(cgid => cgid == cg)));

            return _mapper.Map<IEnumerable<ClientDTO>>(clients);
        }

        public ClientDTO GetClient(string userEmail, int id)
        {
            var cgids = _userRepository.AllAsQueryable
                .Where(u => u.Email == userEmail)
                .SelectMany(u => u.CourseGroupUsers).Select(cg => cg.CourseGroupId);

            var client = _clientRepository.AllAsQueryable
                .Where(c => c.CourseGroupClients
                .Select(cg => cg.CourseGroupId)
                .Any(cg => cgids.Any(cgid => cgid == cg)))
                .FirstOrDefault(c => c.Id == id);

            return _mapper.Map<ClientDTO>(client);
        }
    }
}
