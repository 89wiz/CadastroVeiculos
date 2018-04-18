using CadastroVeiculos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using CadastroVeiculos.Infra.Data.Context.Mapping;

namespace CadastroVeiculos.Infra.Data.Context
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {

        }
        
        public DbSet<Veiculo> Veiculo { get; set; }
        public DbSet<VeiculoFoto> VeiculoFoto { get; set; }
        public DbSet<Proprietario> Proprietario { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new VeiculoMap());
            builder.ApplyConfiguration(new VeiculoFotoMap());
            builder.ApplyConfiguration(new ProprietarioMap());
        }
    }
}
