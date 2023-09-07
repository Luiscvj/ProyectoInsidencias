using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;

public class TrainerConfiguration : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
     builder.ToTable("usuario");
    

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
            });
  
     builder.HasOne(x => x.Persona)
            .WithOne(X => X.Usuario)
            .HasForeignKey<Usuario>(x => x.usuarioDePersona);

        }
}