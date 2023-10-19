using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class TareaConfiguration : IEntityTypeConfiguration<Tarea>
    {
        public void Configure(EntityTypeBuilder<Tarea> builder)
        {
            builder.ToTable("Tareas");
            builder.HasKey(c => c.Id);
            builder.HasIndex(c => c.CategoriaId).IsUnique(false);

            builder.Property(p => p.Titulo)
                .HasColumnName("Titulo")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.Descripcion)
                .HasColumnName("Descripcion")
                .HasMaxLength(300)
                .IsRequired();

            builder.Property(p => p.FechaLimite)
                .HasColumnName("FechaLimite")
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(p => p.CategoriaId)
               .HasColumnName("CategoriaId")
               .HasMaxLength(30)
               .IsRequired();

            builder.Property(p => p.Created)
                .HasColumnName("FechaCreacion")
                .HasMaxLength(30);

            builder.Property(p => p.LastModified)
                .HasColumnName("UltimaFechaModificacion")
                .HasMaxLength(30);

            builder.Property(p => p.Estado)
              .HasColumnName("Estado")
              .HasMaxLength(30);
            
            builder.Property(p => p.Activo)
                .HasColumnName("Activo").HasDefaultValue(1);
        }
    }
}
