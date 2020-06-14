using System;
using System.Collections.Generic;
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
    [Produces("application/json")]
    public class MyControllerBase<Entity, EntityDTO> : ControllerBase
        where Entity : EntityBase
        where EntityDTO : DTOBase
    {
        private readonly ILogger<AtivoRendaVariavelController> _logger;
        private readonly IServiceBase<Entity> _service;
        private readonly IMapper _mapper;

        //*******************************************************************
        //TODO: async, usar o _logger, uow
        //*******************************************************************

        public MyControllerBase(ILogger<AtivoRendaVariavelController> logger, IServiceBase<Entity> service, IMapper mapper)
        {
            _logger = logger;
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Get()
        {
            try
            {
                var entities = _mapper.Map<IEnumerable<EntityDTO>>(_service.Get());
                return new OkObjectResult(entities);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var entity = _mapper.Map<EntityDTO>(_service.GetById(id));
                return new OkObjectResult(entity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Insert([FromBody] EntityDTO entityDTO)
        {
            try
            {
                var entity = _mapper.Map<Entity>(entityDTO);
                return new OkObjectResult(_service.Insert(entity));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Update([FromBody] EntityDTO entityDTO)
        {
            try
            {
                var entity = _mapper.Map<Entity>(entityDTO);
                _service.Update(entity);
                return new OkObjectResult(true);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _service.Delete(id);
                return new OkObjectResult(true);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}