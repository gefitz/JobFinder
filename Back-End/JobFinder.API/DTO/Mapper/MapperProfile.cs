using AutoMapper;
using JobFinder.Data.Model;

namespace JobFinder.API.DTO.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile() { 
            CreateMap<CandidatoModel, CandidatoDTO>().ReverseMap();
            CreateMap<CandidatoInsertModel,CandidatoDTO>().ReverseMap();
        }
    }
}
