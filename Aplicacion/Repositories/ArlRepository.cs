using Dominio.Interfaces;

namespace Aplicacion.Repositories;

public class ArlRepository : GenericRepository<Arl> , IArl
{

    public ArlRepository(InsidenciasContext context) :base(context)
    {
        
    }
}