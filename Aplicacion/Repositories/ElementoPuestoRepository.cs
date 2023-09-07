using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Aplicacion.Repositories;

public class ElementoPuestoRepository : GenericRepository<ElementoPuesto>, IElementoPuesto
{

    protected readonly InsidenciasContext _context;
    public ElementoPuestoRepository(InsidenciasContext context) : base(context)
    {
        _context = context;
    }


     public override async Task<(int totalRegistros, IEnumerable<ElementoPuesto> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query = _context.ElementosPuestos as IQueryable<ElementoPuesto>;



        var totalRegistros = await query.CountAsync();
        var registros = await query
                                .Include(u => u.PuestoId)
                                .Include(u => u.ElementoId)
                                .Skip((pageIndex -1) * pageSize)
                                .Take(pageSize)
                                .ToListAsync();

        return(totalRegistros, registros);

    }
}