using Dominio.Interfaces;

namespace Aplicacion.Repositories;

public class SesionUsoRepository : GenericRepository<SesionUso> , ISesionUso
{
   

    public SesionUsoRepository(InsidenciasContext context) :base(context)
    {
        
    }
}