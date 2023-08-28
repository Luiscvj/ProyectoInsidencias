using Dominio.Interfaces;

namespace Aplicacion.Repositories;


public class DepartamentoRepository : GenericRepository<Departamento> , IDepartamento
{
    protected readonly InsidenciasContext _context;

    public DepartamentoRepository(InsidenciasContext context): base(context)
    {
        _context = context;
    }
}