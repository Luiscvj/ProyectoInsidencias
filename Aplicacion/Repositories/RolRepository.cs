using Dominio.Interfaces;

namespace Aplicacion.Repositories;

public class RolRepository : GenericRepository<Rol> , IRol
{
 

    public RolRepository(InsidenciasContext context) :base(context)
    {
        
    }
}