using Dominio.Interfaces;

namespace Aplicacion.Repositories;

public class CiudadRepository : GenericRepository<Ciudad> , ICiudad
{
    

    public CiudadRepository(InsidenciasContext context) :base(context)
    {
      
    }
}