using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;
using System.Reflection.Metadata;

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

            builder.Property(p => p.Activo)
               .HasColumnName("Activo").HasDefaultValue(1);

           builder.HasOne(e => e.Tarea)
              .WithOne(e => e.Categoria)
              .HasForeignKey<Tarea>(e => e.CategoriaId)
              .IsRequired();
        }
    }
}
