using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Aplicacion.Repositories;

public class SalonRepository : GenericRepository<Salon> , ISalon
{
    protected readonly InsidenciasContext  _context;

    public SalonRepository(InsidenciasContext context) :base(context)
    {
        _context = context;
    }


     public override async Task<(int totalRegistros, IEnumerable<Salon> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query = _context.ElementosPuestos as IQueryable<Salon>;

         if(!string.IsNullOrEmpty(search))
        {
            query = query.Where(p => p.Nombre.ToLower().Contains(search));
        }

        var totalRegistros = await query.CountAsync();
        var registros = await query
                                .Include(u => u.Puestos)
                                .Skip((pageIndex -1) * pageSize)
                                .Take(pageSize)
                                .ToListAsync();

        return(totalRegistros, registros);

    }
}