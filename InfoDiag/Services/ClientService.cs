namespace Services
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using Constants.Enums;
    using Entity.DTO;
    using Repositories.Interfaces;
    using Services.Interfaces;

    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IUserRepository _userRepository;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public ClientService(IClientRepository clientRepository, IUserRepository userRepository, IUserService userService, IMapper mapper)
        {
            _clientRepository = clientRepository;
            _userRepository = userRepository;
            _userService = userService;
            _mapper = mapper;
        }

        public IEnumerable<ClientDTO> GetAllClients(string userEmail)
        {
            var userIds = _userService.RelatedUserIds(userEmail);

            return _mapper.Map<IEnumerable<ClientDTO>>(_userRepository.AllAsQueryable.Where(u => userIds.Contains(u.Id)).SelectMany(u => u.CourseGroups).SelectMany(cg => cg.Clients));
        }
    }
}
