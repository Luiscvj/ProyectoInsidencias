using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;

public class ElementoPuestoConfiguration : IEntityTypeConfiguration<ElementoPuesto>
{
    public void Configure(EntityTypeBuilder<ElementoPuesto> builder)
    {
        builder.ToTable("elemento_puesto");
        builder.HasKey(e => e.Id);

    }
}