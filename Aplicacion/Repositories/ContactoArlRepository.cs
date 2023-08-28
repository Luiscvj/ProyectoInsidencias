using Dominio.Interfaces;

namespace Aplicacion.Repositories;


public class ContactoArlRepository : GenericRepository<ContactoArl> , IContactoArl
{
  

    public ContactoArlRepository(InsidenciasContext context): base(context)
    {
     
    }
}