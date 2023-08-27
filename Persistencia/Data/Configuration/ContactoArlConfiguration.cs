using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;

public class ContactoArlConfiguration : IEntityTypeConfiguration<ContactoArl>
{
    public void Configure(EntityTypeBuilder<ContactoArl> builder)
    {
        builder.ToTable("contacto_arl");
        builder.Property(ca => ca.Contacto)
        .HasMaxLength(20);
        
    }
}