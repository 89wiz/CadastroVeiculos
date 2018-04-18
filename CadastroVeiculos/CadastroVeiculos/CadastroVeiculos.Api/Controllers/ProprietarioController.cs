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
    public class ProprietarioController : BaseController
    {
        private readonly IProprietarioAppService _service;
        private readonly IMapper _mapper;

        public ProprietarioController(IProprietarioAppService service,
            IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var proprietarios = _service.GetAll();
            var proprietariosMapper = _mapper.Map<IEnumerable<ProprietarioListarViewModel>>(proprietarios);

            return new OkObjectResult(proprietariosMapper);
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            if (string.IsNullOrEmpty(id)) return BadRequest();
            Guid guid;
            var success = Guid.TryParse(id, out guid);
            var Proprietario = _service.Get(guid);

            var vm = _mapper.Map<ProprietarioEditarViewModel>(Proprietario);
            if (vm == null) return NotFound();

            return new OkObjectResult(vm);
        }

        [HttpPost()]
        public IActionResult Create([FromBody]ProprietarioEditarViewModel vm)
        {
            if (vm == null) return BadRequest();
            //vm.UserName = GetUserName;

            var proprietario = _mapper.Map<Proprietario>(vm);
            //TODO: Adicionar na Tela.

            var validationResult = _service.Create(proprietario);
            if (validationResult.IsValid) return new CreatedResult("/Proprietario", proprietario.ID); //TODO: Link de Retorno.

            return BadRequest(Errors.AddErrosToModelState(validationResult, ModelState));
        }

        [HttpPut()]
        public IActionResult Alter([FromBody]ProprietarioEditarViewModel vm)
        {
            if (vm == null) return BadRequest();
            //vm.UserName = GetUserName;

            var proprietario = _mapper.Map<Proprietario>(vm);

            var validationResult = _service.Update(proprietario);
            if (validationResult.IsValid) return new OkObjectResult(proprietario.ID); //TODO: Link de Retorno.

            return BadRequest(Errors.AddErrosToModelState(validationResult, ModelState));
        }
    }
}