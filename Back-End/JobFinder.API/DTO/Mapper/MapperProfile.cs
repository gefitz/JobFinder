using AutoMapper;
using JobFinder.Data.Model;

namespace JobFinder.API.DTO.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile() { 
            CreateMap<UsuarioModel, UsuarioDTO>().ReverseMap();
            CreateMap<UsuarioInsertModel, UsuarioDTO>().ReverseMap();
            CreateMap<CidadeModel,CidadeDTO>().ReverseMap();
        }
    }
}
