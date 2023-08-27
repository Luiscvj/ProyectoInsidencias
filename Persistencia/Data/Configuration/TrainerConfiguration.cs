using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;

public class TrainerConfiguration : IEntityTypeConfiguration<Trainer>
{
    public void Configure(EntityTypeBuilder<Trainer> builder)
    {
     builder.ToTable("trainer");
     builder.HasOne(x => x.Ciudad)
        .WithMany(x => x.Trainers)
        .HasForeignKey(x => x.CiudadId);

     builder.HasOne(x => x.Genero)
         .WithMany(x => x.Trainers)
         .HasForeignKey(x => x.GeneroId);
     builder.HasOne(x => x.TipoPersona)
         .WithMany(x => x.Trainers)
         .HasForeignKey(X =>X.TipoPersonaId);
     builder.HasOne(x => x.Direccion)
         .WithMany(x => x.Trainers)
         .HasForeignKey(X =>X.DireccionId);
     builder.HasOne(x => x.Arl)
         .WithMany(x => x.Trainers)
         .HasForeignKey(X =>X.ArlId);
     builder.HasOne(x => x.Eps)
         .WithMany(x => x.Trainers)
         .HasForeignKey(X =>X.EpsId);

     

        }
}