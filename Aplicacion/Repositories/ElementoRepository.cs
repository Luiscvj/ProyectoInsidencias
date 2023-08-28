using Dominio.Interfaces;

namespace Aplicacion.Repositories;


public class ElementoRepository : GenericRepository<Elemento> , IElemento
{
    protected readonly InsidenciasContext _context;

    public ElementoRepository(InsidenciasContext context): base(context)
    {
        _context = context;
    }
}