using Dominio.Interfaces;

namespace Aplicacion.Repositories;

public class PuestoRepository : GenericRepository<Puesto> , IPuesto
{
    protected readonly InsidenciasContext _context;

    public PuestoRepository(InsidenciasContext context) :base(context)
    {
        _context = context;
    }
}