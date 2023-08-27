using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;


public class DepartamentoConfiguration : IEntityTypeConfiguration<Departamento>
{
    public void Configure(EntityTypeBuilder<Departamento> builder)
    {
        builder.ToTable("departamento");
        builder.Property(d => d.NombreDep)
        .HasMaxLength(90);

        builder.HasOne(d => d.Pais)
        .WithMany(p => p.Departamentos)
        .HasForeignKey(d => d.PaisId);
        
        
    }
}
