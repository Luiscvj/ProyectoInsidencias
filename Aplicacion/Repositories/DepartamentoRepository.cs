using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Aplicacion.Repositories;


public class DepartamentoRepository : GenericRepository<Departamento> , IDepartamento
{
    private readonly  InsidenciasContext _context;

    public DepartamentoRepository(InsidenciasContext context): base(context)
    {
        _context = context;
    }
   
    


    public override async Task<IEnumerable<Departamento>> GetAll( )
    {
        var Deps = await  _context.Departamentos
                    .Include(d => d.Ciudades)
                    .ToListAsync();

         return Deps;
        
                    
    }

    public override async Task<(int totalRegistros, IEnumerable<Departamento> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query = _context.Departamentos as IQueryable<Departamento>;

        if(!string.IsNullOrEmpty(search))
        {
            query = query.Where(p => p.NombreDep.ToLower().Contains(search));
        }

        var totalRegistros = await query.CountAsync();
        var registros = await query
                                .Include(u => u.Ciudades)
                                .Skip((pageIndex -1) * pageSize)
                                .Take(pageSize)
                                .ToListAsync();

        return(totalRegistros, registros);
    }
}