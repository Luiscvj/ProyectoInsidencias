using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;

public class TipoContactoConfiguration : IEntityTypeConfiguration<TipoContacto>
{
    public void  Configure(EntityTypeBuilder<TipoContacto> builder)
    {
        builder.ToTable("tipo_contacto");

        builder.Property(x => x.NombreTipo)
        .HasMaxLength(80);
    }
}