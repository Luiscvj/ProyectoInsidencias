using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;

public class InsidenciaConfiguration : IEntityTypeConfiguration<Insidencia>
{
    public void Configure(EntityTypeBuilder<Insidencia> builder)
    {
        builder.ToTable("insidencia");

        builder.Property(x => x.FechaReporte)
        .HasColumnType("date");

        builder.Property (x => x.Descripcion)
        .HasMaxLength(1000);

        builder.HasOne(x => x.Categoria)
        .WithMany(c => c.Insidencias)
        .HasForeignKey(x => x.CategoriaId);

        builder.HasOne(x => x.Tipo_Gravedad)
        .WithMany(x => x.Insidencias)
        .HasForeignKey(x => x.Tipo_GravedadId);

        builder.HasMany(x => x.ElementoPuestos)
        .WithMany(e => e.Insidencias)
        .UsingEntity
        (
            j => {j.ToTable("elementos_puesto_insidencia");}

          
        );

        builder.HasOne(x => x.Trainer)
        .WithMany(x => x.Insidencias)
        .HasForeignKey(x => x.TrainerId);


    }
}