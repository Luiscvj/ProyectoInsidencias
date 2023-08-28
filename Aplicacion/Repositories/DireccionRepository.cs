
using Dominio.Interfaces;

namespace Aplicacion.Repositories;


public class DireccionRepository : GenericRepository<Direccion> , IDireccion
{
    protected readonly InsidenciasContext _context;

    public DireccionRepository(InsidenciasContext context): base(context)
    {
        _context = context;
    }
}