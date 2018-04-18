using CadastroVeiculos.Application;
using CadastroVeiculos.Application.Interfaces;
using CadastroVeiculos.Domain.Interfaces.Repository;
using CadastroVeiculos.Domain.Interfaces.Repository.Common;
using CadastroVeiculos.Domain.Interfaces.Service;
using CadastroVeiculos.Domain.Services;
using CadastroVeiculos.Infra.Data.Context;
using CadastroVeiculos.Infra.Data.Context.Interfaces;
using CadastroVeiculos.Infra.Data.Repository.EntityFramework;
using CadastroVeiculos.Infra.Data.Repository.EntityFramework.Common;
using Microsoft.Extensions.DependencyInjection;

namespace CadastroVeiculos.Infra.CrossCutting.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //Infra
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            //Domain Services
            services.AddScoped<IVeiculoService, VeiculoService>();

            // App Services
            services.AddScoped<IVeiculoAppService, VeiculoAppService>();

            // Repository
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IVeiculoRepository, VeiculoRepository>();
        }
    }
}
