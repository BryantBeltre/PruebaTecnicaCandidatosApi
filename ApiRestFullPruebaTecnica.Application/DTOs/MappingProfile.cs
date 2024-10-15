using ApiRestFullPruebaTecnica.Application.DTOs.Candidatos;
using ApiRestFullPruebaTecnica.Application.DTOs.Metrics;
using ApiRestFullPruebaTecnica.Domain.Entities;
using AutoMapper;


namespace ApiRestFullPruebaTecnica.Application.DTOs
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //candidato mapping
            CreateMap<CreateCandidatosDto, Candidato>().ReverseMap();
            CreateMap<UpdateCandidatosDto, Candidato>().ReverseMap();
            CreateMap<CandidatoDto, Candidato>().ReverseMap();

            //AppMetric mappings
            CreateMap<ApiMetricDto, ApiMetric>().ReverseMap();

        }
    }
}
