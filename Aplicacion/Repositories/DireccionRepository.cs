
using Dominio.Interfaces;

namespace Aplicacion.Repositories;


public class DireccionRepository : GenericRepository<Direccion> , IDireccion
{
    

    public DireccionRepository(InsidenciasContext context): base(context)
    {
        
    }
}