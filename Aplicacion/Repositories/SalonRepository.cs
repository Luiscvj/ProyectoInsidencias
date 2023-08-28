using Dominio.Interfaces;

namespace Aplicacion.Repositories;

public class SalonRepository : GenericRepository<Salon> , ISalon
{
    protected readonly InsidenciasContext _context;

    public SalonRepository(InsidenciasContext context) :base(context)
    {
        _context = context;
    }
}