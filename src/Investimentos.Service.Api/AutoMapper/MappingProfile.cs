using AutoMapper;
using Investimentos.Domain.Entities;
using Investimentos.Service.Api.DTOs;

namespace Investimentos.Service.Api.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AtivoRendaVariavel, AtivoRendaVariavelDTO>();

            CreateMap<AtivoRendaVariavelDTO, AtivoRendaVariavel>();
        }
    }
}
