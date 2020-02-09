namespace Services.Profiles
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using AutoMapper;
    using Entity;
    using Entity.DTO;

    public class TermProfile : Profile
    {
        public TermProfile()
        {
            CreateMap<Term, TermDto>();
        }
    }
}
