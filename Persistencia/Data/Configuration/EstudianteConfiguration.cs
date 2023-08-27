using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;

public class EstudianteConfiguration : IEntityTypeConfiguration<Estudiante>
{
    public void Configure(EntityTypeBuilder<Estudiante> builder)
    {
        builder.ToTable("estudiante");

        builder.HasOne(e => e.Genero)
        .WithMany(g => g.Estudiantes)
        .HasForeignKey(e => e.GeneroId);

        builder.HasOne( e=> e.Direccion)
        .WithMany(d => d.Estudiantes)
        .HasForeignKey(e => e.DireccionId);

    }
}