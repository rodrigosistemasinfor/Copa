using AutoMapper;
using CopaApp.Domain;
using CopaApp.Infra.Data.Entities;

namespace CopaApp.Infra.CrossCutting
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<EquipeEntity, EquipeDomain>();
            CreateMap<EquipeDomain, EquipeEntity>();
        }
    }
}
