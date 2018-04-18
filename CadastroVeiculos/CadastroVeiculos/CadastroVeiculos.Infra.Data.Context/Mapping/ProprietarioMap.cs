using CadastroVeiculos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CadastroVeiculos.Infra.Data.Context.Mapping
{
    public class ProprietarioMap : IEntityTypeConfiguration<Proprietario>
    {
        public void Configure(EntityTypeBuilder<Proprietario> builder)
        {
            builder.ToTable("Proprietario")
                .HasKey(b => b.ID);

            builder.Property(b => b.ID)
                .IsRequired();

            builder.Property(b => b.Nome)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(b => b.CPF)
                .HasMaxLength(11)
                .IsRequired();

            builder.Ignore(b => b.ValidationResult);
        }
    }
}
