using Dominio.Interfaces;

namespace Aplicacion.Repositories;

public class TipoPersonaRepository : GenericRepository<TipoPersona> , ITipoPersona
{
    protected readonly InsidenciasContext _context;

    public TipoPersonaRepository(InsidenciasContext context) :base(context)
    {
        _context = context;
    }
}