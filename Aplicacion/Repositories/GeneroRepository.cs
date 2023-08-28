using Dominio.Interfaces;

namespace Aplicacion.Repositories;

public class GeneroRepository : GenericRepository<Genero> , IGenero
{
    protected readonly InsidenciasContext _context;

    public GeneroRepository(InsidenciasContext context) :base(context)
    {
        _context = context;
    }
}