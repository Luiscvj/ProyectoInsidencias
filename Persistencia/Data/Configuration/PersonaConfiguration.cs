using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;


public class PersonaConfiguration  : IEntityTypeConfiguration<Persona>
{
    public void  Configure(EntityTypeBuilder<Persona> builder)
    {
        builder.ToTable("persona");

        builder.HasMany(x => x.Puestos)
            .WithMany(x => x.Personas)
            .UsingEntity<SesionUso>(
        j=>
        {
            j.HasOne(x => x.Persona)
        .WithMany(x => x.SesionUsos)
        .HasForeignKey(x => x.PersonaId);
         
        j.HasOne(x => x.Puesto)
        .WithMany(x => x.SesionUsos)
        .HasForeignKey(x => x.PuestoID);

    });

   


    builder.HasOne(x => x.Direccion)
         .WithMany(x => x.Personas)
         .HasForeignKey(X =>X.DireccionId);
     builder.HasOne(x => x.Arl)
         .WithMany(x => x.Personas)
         .HasForeignKey(X =>X.ArlId);
     builder.HasOne(x => x.Eps)
         .WithMany(x => x.Personas)
         .HasForeignKey(X =>X.EpsId);

    builder.HasOne(x => x.Ciudad)
        .WithMany(x => x.Personas)
        .HasForeignKey(x => x.CiudadId);

     builder.HasOne(x => x.Genero)
         .WithMany(x => x.Personas)
         .HasForeignKey(x => x.GeneroId);
    }


}