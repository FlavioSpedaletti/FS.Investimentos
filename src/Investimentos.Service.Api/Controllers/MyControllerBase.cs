﻿using System;
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
        private readonly ILogger _logger;
        private readonly IServiceBase<Entity> _service;
        private readonly IMapper _mapper;

        public MyControllerBase(ILogger logger, IServiceBase<Entity> service, IMapper mapper)
        {
            _logger = logger;
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("")]
        public virtual IActionResult Get()
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
        public virtual IActionResult GetById(int id)
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
        public virtual IActionResult Insert([FromBody] EntityDTO entityDTO)
        {
            try
            {
                var entity = _mapper.Map<Entity>(entityDTO);
                var entityId = _service.Insert(entity);

                return new OkObjectResult(entityId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public virtual IActionResult Update([FromBody] EntityDTO entityDTO)
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
        public virtual IActionResult Delete(int id)
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