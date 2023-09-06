using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;

public class PuestoConfiguration : IEntityTypeConfiguration<Puesto>
{
    public void Configure(EntityTypeBuilder<Puesto> builder)
    {
        builder.ToTable("puesto");

        builder.HasOne(p => p.Salon)
        .WithMany(s => s.Puestos)
        .HasForeignKey(p => p.SalonId);

        builder.HasMany(p => p.Usuarios)
        .WithMany(e => e.Puestos)
        .UsingEntity<SesionUso>();


    }
}