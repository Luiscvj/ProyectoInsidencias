using Dominio.Interfaces;

namespace  Aplicacion.Repositories;

public class AreaRepository : GenericRepository<Area>,IArea
{

   
    public AreaRepository(InsidenciasContext context) : base(context)
    {
        
    }
}