using Dominio.Interfaces;

namespace Aplicacion.Repositories;


public class ContactoEpsRepository : GenericRepository<ContactoEps> , IContactoEps
{


    public ContactoEpsRepository(InsidenciasContext context): base(context)
    {
       
    }
}