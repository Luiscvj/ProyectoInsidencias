using Dominio.Interfaces;

namespace Aplicacion.Repositories;

public class SesionRepository : GenericRepository<Sesion> , ISesion
{
    protected readonly InsidenciasContext _context;

    public SesionRepository(InsidenciasContext context) :base(context)
    {
        _context = context;
    }
}