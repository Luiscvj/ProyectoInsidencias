using Dominio.Interfaces;

namespace Aplicacion.Repositories;

public class TipoPersonaRepository : GenericRepository<TipoPersona> , ITipoPersona
{
 

    public TipoPersonaRepository(InsidenciasContext context) :base(context)
    {
        
    }
}