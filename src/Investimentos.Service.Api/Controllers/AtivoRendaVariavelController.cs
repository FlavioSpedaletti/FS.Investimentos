using AutoMapper;
using Investimentos.Domain.Entities;
using Investimentos.Domain.Interfaces.Services;
using Investimentos.Service.Api.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Investimentos.Service.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtivoRendaVariavelController : MyControllerBase<AtivoRendaVariavel, AtivoRendaVariavelDTO>
    {
        public AtivoRendaVariavelController(ILogger<AtivoRendaVariavelController> logger, IAtivoRendaVariavelService ativoRendaVariavelService, IMapper mapper) : base(logger, ativoRendaVariavelService, mapper)
        {
            logger.LogCritical("entrou no ctor");
        }

        //public AtivoRendaVariavelController(ILogger<AtivoRendaVariavelController> logger, IAtivoRendaVariavelService ativoRendaVariavelService, IMapper mapper)
        //{
        //    _logger = logger;
        //    _ativoRendaVariavelService = ativoRendaVariavelService;
        //    _mapper = mapper;
        //}

        //[HttpGet]
        //public IEnumerable<AtivoRendaVariavelDTO> Get()
        //{
        //    return _mapper.Map<IEnumerable<AtivoRendaVariavelDTO>>(_ativoRendaVariavelService.Get());
        //}

        //[HttpGet]
        //public AtivoRendaVariavelDTO GetById(int id)
        //{
        //    return _mapper.Map<AtivoRendaVariavelDTO>(_ativoRendaVariavelService.GetById(id));
        //}
    }
}