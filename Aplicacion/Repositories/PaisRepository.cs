using Dominio.Interfaces;

namespace Aplicacion.Repositories;

public class PaisRepository : GenericRepository<Pais> , IPais
{
    protected readonly InsidenciasContext _context;

    public PaisRepository(InsidenciasContext context) :base(context)
    {
        _context = context;
    }
}