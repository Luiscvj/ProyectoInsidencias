using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;

public class ElementoConfiguraion : IEntityTypeConfiguration<Elemento>
{
    public void Configure(EntityTypeBuilder<Elemento> builder)
    {
        builder.ToTable("elemento");

        builder.Property(e => e.Descripcion)
        .HasMaxLength(255);

        builder.HasOne(e => e.Categoria)
        .WithMany(c => c.Elementos)
        .HasForeignKey(e => e.CategoriaId);

        builder.HasMany(e => e.Puestos)
        .WithMany(p => p.Elementos)
        .UsingEntity<ElementoPuesto>();
    }
}