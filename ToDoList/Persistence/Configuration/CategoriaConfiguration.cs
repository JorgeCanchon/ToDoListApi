using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class CategoriaConfiguration : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable("Categorias");
            builder.HasKey(c => c.Id);

            builder.Property(p => p.Nombre)
                .HasColumnName("Nombre")
                .HasMaxLength(80)
                .IsRequired();

            builder.Property(p => p.Created)
                .HasColumnName("FechaCreacion")
                .HasMaxLength(30);

            builder.Property(p => p.LastModified)
                .HasColumnName("UltimaFechaModificacion")
                .HasMaxLength(30);

            builder.Property(p => p.Estado)
               .HasColumnName("Estado").HasDefaultValue(1);
        }
    }
}
