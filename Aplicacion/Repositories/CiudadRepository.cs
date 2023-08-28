using Dominio.Interfaces;

namespace Aplicacion.Repositories;

public class CiudadRepository : GenericRepository<Ciudad> , ICiudad
{
    protected readonly InsidenciasContext _context;

    public CiudadRepository(InsidenciasContext context) :base(context)
    {
        _context = context;
    }
}