using Dominio.Interfaces;

namespace Aplicacion.Repositories;

public class ElementoPuestoRepository : GenericRepository<ElementoPuesto>, IElementoPuesto
{
    protected readonly InsidenciasContext _context;
    public ElementoPuestoRepository(InsidenciasContext context) : base(context)
    {
        _context    = context;
    }
}