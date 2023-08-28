using Dominio.Interfaces;

namespace Aplicacion.Repositories;

public class SesionUsoRepository : GenericRepository<SesionUso> , ISesionUso
{
    protected readonly InsidenciasContext _context;

    public SesionUsoRepository(InsidenciasContext context) :base(context)
    {
        _context = context;
    }
}