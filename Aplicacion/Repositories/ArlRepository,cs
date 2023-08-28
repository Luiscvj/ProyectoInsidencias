using Dominio.Interfaces;

namespace Aplicacion.Repositories;

public class ArlRepository : GenericRepository<Arl> , IArl
{
    protected readonly InsidenciasContext _context;

    public ArlRepository(InsidenciasContext context) :base(context)
    {
        _context = context;
    }
}