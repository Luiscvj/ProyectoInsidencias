using Dominio.Interfaces;

namespace  Aplicacion.Repositories;

public class AreaRepository : GenericRepository<Area>,IArea
{

    protected readonly  InsidenciasContext _context;

    public AreaRepository(InsidenciasContext context) : base(context)
    {
        _context = context;
    }
}