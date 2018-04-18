using CadastroVeiculos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CadastroVeiculos.Infra.Data.Context.Mapping
{
    public class VeiculoFotoMap : IEntityTypeConfiguration<VeiculoFoto>
    {
        public void Configure(EntityTypeBuilder<VeiculoFoto> builder)
        {
            builder.ToTable("VeiculoFoto")
                .HasKey(b => b.ID);

            builder.Property(b => b.ID)
                .IsRequired();

            builder.Property(b => b.ArquivoID)
                .IsRequired();

            builder.Property(b => b.VeiculoID)
                .IsRequired();
            
            builder.HasOne(o => o.Veiculo)
                .WithMany(o => o.Fotos)
                .HasForeignKey(o => o.VeiculoID)
                .HasPrincipalKey(o => o.ID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Ignore(b => b.ValidationResult);
        }
    }
}
