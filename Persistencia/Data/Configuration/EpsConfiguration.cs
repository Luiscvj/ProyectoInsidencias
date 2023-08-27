using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;

public class EpsConfiguration : IEntityTypeConfiguration<Eps>
{
    public void Configure(EntityTypeBuilder<Eps> builder)
    {
        builder.ToTable("eps");
        builder.HasMany( e=> e.TipoContactos)
        .WithMany(tc => tc.Epss)
        .UsingEntity<ContactoEps>();
      

    }
}