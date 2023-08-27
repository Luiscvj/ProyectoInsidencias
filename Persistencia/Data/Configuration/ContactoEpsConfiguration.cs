using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;


public class ContactoEpsConfiguration : IEntityTypeConfiguration<ContactoEps>
{
    public void Configure(EntityTypeBuilder<ContactoEps> builder)
    {
        builder.ToTable("contacto_eps");
        builder.Property(ce => ce.Contacto)
        .HasMaxLength(20);
    }
}
