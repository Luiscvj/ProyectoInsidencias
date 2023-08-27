using System.IO.Compression;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;


public class CiudadConfiguration: IEntityTypeConfiguration<Ciudad>
{
    public void Configure(EntityTypeBuilder<Ciudad> builder)
    {
        builder.ToTable("ciudad");
        builder.Property(c => c.Nombre)
        .HasMaxLength(90);

        builder.HasOne(c => c.Departamento)
        .WithMany(d => d.Ciudades)
        .HasForeignKey(d => d.DepartamentoId);
    }
}