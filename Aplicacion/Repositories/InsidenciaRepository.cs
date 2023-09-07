using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Aplicacion.Repositories;

public class InsidenciaRepository : GenericRepository<Insidencia> , IInsidencia
{
    protected readonly InsidenciasContext _context;

    public InsidenciaRepository(InsidenciasContext context) :base(context)
    {
       _context = context;
    }

    public override async Task<(int totalRegistros, IEnumerable<Insidencia> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query = _context.Insidencias as IQueryable<Insidencia>;

        

        var totalRegistros = await query.CountAsync();
        var registros = await query
                                .Include(u => u.ElementoPuestos)
                                .Skip((pageIndex -1) * pageSize)
                                .Take(pageSize)
                                .ToListAsync();

        return(totalRegistros, registros);
    }


}