using AutoMapper;
using Investimentos.Domain.Entities;
using Investimentos.Domain.Interfaces.Services;
using Investimentos.Service.Api.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace Investimentos.Service.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtivoRendaVariavelController : MyControllerBase<AtivoRendaVariavel, AtivoRendaVariavelDTO>
    {
        private readonly ILogger<AtivoRendaVariavelController> _logger;
        private readonly IAtivoRendaVariavelService _ativoRendaVariavelService;
        private readonly IMapper _mapper;

        public AtivoRendaVariavelController(ILogger<AtivoRendaVariavelController> logger, IAtivoRendaVariavelService ativoRendaVariavelService, IMapper mapper) : base(logger, ativoRendaVariavelService, mapper)
        {
            _logger = logger;
            _ativoRendaVariavelService = ativoRendaVariavelService;
            _mapper = mapper;
            
            _logger.LogCritical("entrou no ctor");
        }

        [HttpGet]
        [Route("")]
        public override IActionResult Get()
        {
            try
            {
                var id1 = _mapper.Map<AtivoRendaVariavelDTO>(_ativoRendaVariavelService.GetById(1));
                var id2 = _mapper.Map<AtivoRendaVariavelDTO>(_ativoRendaVariavelService.GetById(2));
                //não vai no banco novamente
                var id1Again = _mapper.Map<AtivoRendaVariavelDTO>(_ativoRendaVariavelService.GetById(1));

                //vai no banco, mas só pra pegar os ids diferentes dos já trackeados anteriormente (1 e 2)
                var entities = _mapper.Map<IEnumerable<AtivoRendaVariavelDTO>>(_ativoRendaVariavelService.Get());

                return new OkObjectResult(entities);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("MetodoComMaisDeUmaTransacao")]
        public void MetodoComMaisDeUmaTransacao()
        {
            _ativoRendaVariavelService.MetodoComMaisDeUmaTransacao();
        }

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