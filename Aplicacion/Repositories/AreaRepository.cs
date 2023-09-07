using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace  Aplicacion.Repositories;

public class AreaRepository : GenericRepository<Area>,IArea
{
    protected readonly InsidenciasContext _context;

   
    public AreaRepository(InsidenciasContext context) : base(context)
    {
        _context  = context;
    }



    public override async Task<(int totalRegistros, IEnumerable<Area> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query = _context.Areas as IQueryable<Area>;

        if(!string.IsNullOrEmpty(search))
        {
            query = query.Where(p => p.Nombre.ToLower().Contains(search));
        }

        var totalRegistros = await query.CountAsync();
        var registros = await query
                                .Include(u => u.Salones)
                                .Skip((pageIndex -1) * pageSize)
                                .Take(pageSize)
                                .ToListAsync();

        return(totalRegistros, registros);

    }
}