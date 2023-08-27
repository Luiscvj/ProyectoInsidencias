using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;


public class DireccionConfiguration : IEntityTypeConfiguration<Direccion>
{
    public void Configure(EntityTypeBuilder<Direccion> builder)
    {
        builder.ToTable("direccion");
        builder.Property(d => d.TipoVia)
        .HasMaxLength(30);

        builder.Property(d => d.Numero)
        .HasMaxLength(4);

        builder.Property(d => d.Letra)
        .HasMaxLength(2);

        builder.Property(d => d.SufijoCardinal)
        .HasMaxLength(10);

        builder.Property(d => d.SufijoCardinalSecundario)
        .HasMaxLength(10);
        
        builder.Property(d => d.NroViaSecundaria)
        .HasMaxLength(10);
        
    }
}