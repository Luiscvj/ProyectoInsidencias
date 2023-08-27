using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;

public class TipoGravedadConfiguration : IEntityTypeConfiguration<Tipo_Gravedad>
{
    public void Configure(EntityTypeBuilder<Tipo_Gravedad> builder)
    {
        builder.ToTable("tipo_gravedad");

        builder.Property(tg => tg.Rubrica)
        .HasMaxLength(400);


    }
}