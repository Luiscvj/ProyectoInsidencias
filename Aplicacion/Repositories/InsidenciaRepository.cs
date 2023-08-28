using Dominio.Interfaces;

namespace Aplicacion.Repositories;

public class InsidenciaRepository : GenericRepository<Insidencia> , IInsidencia
{
    protected readonly InsidenciasContext _context;

    public InsidenciaRepository(InsidenciasContext context) :base(context)
    {
        _context = context;
    }
}