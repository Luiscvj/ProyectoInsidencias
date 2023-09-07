using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace   Persistencia.Data.Configuration;

public class SesionUsoConfiguration : IEntityTypeConfiguration<SesionUso>
{
    public void Configure(EntityTypeBuilder<SesionUso> builder)
    {
        builder.ToTable("sesion_uso");

        builder.Property(su => su.FechaInicio)
        .HasColumnType("date");

        builder.Property(su => su.FechaCierre)
        .HasColumnType("date");

        
    }
}