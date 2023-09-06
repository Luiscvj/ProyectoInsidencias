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
}