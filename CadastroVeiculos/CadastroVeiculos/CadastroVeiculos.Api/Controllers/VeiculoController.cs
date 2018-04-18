using AutoMapper;
using CadastroVeiculos.Api.Controllers.Common;
using CadastroVeiculos.Api.Helpers;
using CadastroVeiculos.Api.ViewModels;
using CadastroVeiculos.Application.Interfaces;
using CadastroVeiculos.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CadastroVeiculos.Api.Controllers
{
    public class VeiculoController : BaseController
    {
        private readonly IVeiculoAppService _service;
        private readonly IMapper _mapper;

        public VeiculoController(IVeiculoAppService service,
            IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var veiculos = _service.GetAll();
            var veiculosMapper = _mapper.Map<IEnumerable<VeiculoListarViewModel>>(veiculos);

            return new OkObjectResult(veiculosMapper);
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            if (string.IsNullOrEmpty(id)) return BadRequest();
            Guid guid;
            var success = Guid.TryParse(id, out guid);
            var Veiculo = _service.Get(guid);

            var vm = _mapper.Map<VeiculoEditarViewModel>(Veiculo);
            if (vm == null) return NotFound();

            return new OkObjectResult(vm);
        }

        [HttpPost()]
        public IActionResult Create([FromBody]VeiculoEditarViewModel vm)
        {
            if (vm == null) return BadRequest();
            //vm.UserName = GetUserName;

            var veiculo = _mapper.Map<Veiculo>(vm);
            //TODO: Adicionar na Tela.

            var validationResult = _service.Create(veiculo);
            if (validationResult.IsValid) return new CreatedResult("/Veiculo", veiculo.ID); //TODO: Link de Retorno.

            return BadRequest(Errors.AddErrosToModelState(validationResult, ModelState));
        }

        [HttpPut()]
        public IActionResult Alter([FromBody]VeiculoEditarViewModel vm)
        {
            if (vm == null) return BadRequest();
            //vm.UserName = GetUserName;

            var veiculo = _mapper.Map<Veiculo>(vm);

            var validationResult = _service.Update(veiculo);
            if (validationResult.IsValid) return new OkObjectResult(veiculo.ID); //TODO: Link de Retorno.

            return BadRequest(Errors.AddErrosToModelState(validationResult, ModelState));
        }
    }
}