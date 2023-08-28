using Dominio.Interfaces;

namespace Aplicacion.Repositories;


public class ContactoEpsRepository : GenericRepository<ContactoEps> , IContactoEps
{
    protected readonly InsidenciasContext _context;

    public ContactoEpsRepository(InsidenciasContext context): base(context)
    {
        _context = context;
    }
}