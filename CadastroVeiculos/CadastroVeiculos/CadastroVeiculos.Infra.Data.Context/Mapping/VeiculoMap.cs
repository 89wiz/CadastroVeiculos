using CadastroVeiculos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CadastroVeiculos.Infra.Data.Context.Mapping
{
    public class VeiculoMap : IEntityTypeConfiguration<Veiculo>
    {
        public void Configure(EntityTypeBuilder<Veiculo> builder)
        {
            builder.ToTable("Veiculo")
                .HasKey(b => b.ID);

            builder.Property(b => b.ID)
                .IsRequired();

            builder.Property(b => b.Placa)
                .HasMaxLength(7)
                .IsRequired();

            builder.Property(b => b.Renavam)
                .HasMaxLength(11);

            builder.HasOne(o => o.Proprietario)
                .WithMany()
                .HasPrincipalKey(o => o.ID)
                .OnDelete(DeleteBehavior.Restrict);
            
            builder.HasMany(o => o.Fotos)
                .WithOne();

            builder.Ignore(b => b.ValidationResult);
        }
    }
}
