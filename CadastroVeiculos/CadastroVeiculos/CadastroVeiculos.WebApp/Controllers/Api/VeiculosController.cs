using AutoMapper;
using CadastroVeiculos.Application.Interfaces;
using CadastroVeiculos.Domain.Entities;
using CadastroVeiculos.WebApp.Controllers.Api.Common;
using CadastroVeiculos.WebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CadastroVeiculos.WebApp.Controllers.Api
{
    [Produces("application/json")]
    [Route("api/veiculos")]
    public class VeiculosController : BaseController<IVeiculoAppService, Veiculo>
    {
        public VeiculosController(IVeiculoAppService service, IMapper mapper) : base(service, mapper)
        {

        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var list = _service.GetAll();
                return Json(_mapper.Map<IEnumerable<VeiculoListarViewModel>>(list));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                var veiculo = _service.Get(id);
                if (veiculo == null) return NotFound();

                return Json(Mapper.Map<VeiculoEditarViewModel>(veiculo));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPost()]
        public IActionResult Post([FromBody]VeiculoEditarViewModel veiculo)
        {
            try
            {
                if (veiculo == null) return BadRequest();

                var _veiculo = _mapper.Map<Veiculo>(veiculo);
                var validationResult = _service.Update(_veiculo);

                if (validationResult.IsValid) return Json(_veiculo);
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPut()]
        public IActionResult Put([FromBody]VeiculoEditarViewModel veiculo)
        {
            try
            {
                if (veiculo == null) return BadRequest();

                var _veiculo = _mapper.Map<Veiculo>(veiculo);
                var validationResult = _service.Update(_veiculo);

                if (validationResult.IsValid) return Json(_veiculo);
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var veiculo = _service.Get(id);
                if (veiculo == null) return NotFound();

                var validationResult = _service.Remove(veiculo);
                if (validationResult.IsValid)
                    return Accepted();
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}