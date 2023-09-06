using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;

public class TrainerConfiguration : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
     builder.ToTable("usuario");
     builder.HasOne(x => x.Ciudad)
        .WithMany(x => x.Usuarios)
        .HasForeignKey(x => x.CiudadId);

     builder.HasOne(x => x.Genero)
         .WithMany(x => x.Usuarios)
         .HasForeignKey(x => x.GeneroId);

     builder.HasMany(x => x.Roles)
         .WithMany(x => x.Usuarios)
         .UsingEntity<RolesUsuario>(
            j =>
            {
                j.ToTable("roles_usuario");

                j.HasOne(x => x.Usuario)
                .WithMany(x => x.RolesUsuarios )
                .HasForeignKey(x => x.UsuarioId);
                
                j.HasOne(x => x.Rol)
                .WithMany(x => x.RolesUsuarios)
                .HasForeignKey(x => x.RolId);                
            }
         );

     builder.HasOne(x => x.Direccion)
         .WithMany(x => x.Usuarios)
         .HasForeignKey(X =>X.DireccionId);
     builder.HasOne(x => x.Arl)
         .WithMany(x => x.Usuarios)
         .HasForeignKey(X =>X.ArlId);
     builder.HasOne(x => x.Eps)
         .WithMany(x => x.Usuarios)
         .HasForeignKey(X =>X.EpsId);

     

        }
}