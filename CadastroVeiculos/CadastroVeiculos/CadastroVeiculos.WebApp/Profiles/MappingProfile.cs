using AutoMapper;
using CadastroVeiculos.WebApp.ViewModels;
using CadastroVeiculos.Domain.Entities;

namespace CadastroVeiculos.WebApp.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<VeiculoListarViewModel, Veiculo>();
            CreateMap<VeiculoEditarViewModel, Veiculo>();
            CreateMap<ProprietarioListarViewModel, Proprietario>();
            CreateMap<ProprietarioEditarViewModel, Proprietario>();
            CreateMap<VeiculoFotoViewModel, VeiculoFoto>();
        }       
    }
}