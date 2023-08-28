using Dominio.Interfaces;

namespace Aplicacion.Repositories;


public class ContactoArlRepository : GenericRepository<ContactoArl> , IContactoArl
{
    protected readonly InsidenciasContext _context;

    public ContactoArlRepository(InsidenciasContext context): base(context)
    {
        _context = context;
    }
}