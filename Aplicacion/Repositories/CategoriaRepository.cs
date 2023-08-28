using Dominio.Interfaces;

namespace Aplicacion.Repositories;


public class CategoriaRepository : GenericRepository<Categoria> , ICategoria
{
    protected readonly InsidenciasContext _context;

    public CategoriaRepository(InsidenciasContext context): base(context)
    {
        _context = context;
    }
}