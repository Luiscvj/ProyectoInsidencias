using Dominio.Interfaces;

namespace Aplicacion.Repositories;

public class EpsRepository : GenericRepository<Eps> , IEps
{
    protected readonly InsidenciasContext _context;
    public EpsRepository(InsidenciasContext context)   :base(context)
    {
        _context = context;
    }
}