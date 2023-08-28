using Dominio.Interfaces;

namespace Aplicacion.Repositories;

public class EpsRepository : GenericRepository<Eps> , IEps
{
   
    public EpsRepository(InsidenciasContext context)   :base(context)
    {
        
    }
}