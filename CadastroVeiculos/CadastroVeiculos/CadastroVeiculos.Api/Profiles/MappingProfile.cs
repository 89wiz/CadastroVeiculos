using AutoMapper;
using CadastroVeiculos.Api.ViewModels;
using CadastroVeiculos.Domain.Entities;

namespace CadastroVeiculos.Api.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<VeiculoListarViewModel, Veiculo>();
            CreateMap<VeiculoEditarViewModel, Veiculo>();
            CreateMap<ProprietarioListarViewModel, Proprietario>();
            CreateMap<ProprietarioEditarViewModel, Proprietario>();
        }       
    }
}