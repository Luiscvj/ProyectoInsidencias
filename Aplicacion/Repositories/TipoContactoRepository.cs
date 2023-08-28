using Dominio.Interfaces;

namespace Aplicacion.Repositories;

public class TipoContactoRepository : GenericRepository<TipoContacto> , ITipoContacto
{
    protected readonly InsidenciasContext _context;

    public TipoContactoRepository(InsidenciasContext context) :base(context)
    {
        _context = context;
    }
}