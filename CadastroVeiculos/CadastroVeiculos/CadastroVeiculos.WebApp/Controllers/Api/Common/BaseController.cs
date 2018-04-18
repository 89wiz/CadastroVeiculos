using AutoMapper;
using CadastroVeiculos.Application.Interfaces.Common;
using Microsoft.AspNetCore.Mvc;

namespace CadastroVeiculos.WebApp.Controllers.Api.Common
{
    [Produces("application/json")]
    [Route("api/Base")]
    public class BaseController : Controller
    {
    }

    public class BaseController<TAppService, TEntity> : BaseController
        where TAppService : IBaseAppService<TEntity>
        where TEntity : class
    {
        protected readonly TAppService _service;
        protected readonly IMapper _mapper;

        public BaseController(TAppService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
    }
}