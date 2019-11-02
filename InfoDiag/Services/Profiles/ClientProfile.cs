namespace Services.Profiles
{
    using AutoMapper;
    using Entity;
    using Entity.DTO;

    public class ClientProfile : Profile
    {
        public ClientProfile()
        {
            CreateMap<Client, ClientDTO>();
        }
    }
}
