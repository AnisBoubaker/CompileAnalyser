using AutoMapper;
using Entity;
using Entity.DTO;

namespace Services.Profiles
{
    public class ClientProfile : Profile
    {
        public ClientProfile()
        {
            CreateMap<Client, ClientDTO>();
        }
    }
}
