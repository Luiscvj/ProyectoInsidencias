using Dominio.Interfaces;

namespace Aplicacion.Repositories;

public class UsuarioRepository : GenericRepository<Usuario> , IUsuario
{
    

    public UsuarioRepository(InsidenciasContext context) :base(context)
    {
        
    }
}