using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;

public class ArlConfiguration : IEntityTypeConfiguration<Arl>
{
    public void Configure(EntityTypeBuilder<Arl> builder)
    {
        builder.ToTable("arl");

        builder.HasMany(a => a.TipoContactos)
        .WithMany(tc => tc.Arls)
        .UsingEntity<ContactoArl>();
    }
}