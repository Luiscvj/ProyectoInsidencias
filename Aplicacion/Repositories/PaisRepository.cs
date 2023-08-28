using Dominio.Interfaces;

namespace Aplicacion.Repositories;

public class PaisRepository : GenericRepository<Pais> , IPais
{
  

    public PaisRepository(InsidenciasContext context) :base(context)
    {
        
    }
}