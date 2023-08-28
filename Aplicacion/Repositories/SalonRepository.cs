using Dominio.Interfaces;

namespace Aplicacion.Repositories;

public class SalonRepository : GenericRepository<Salon> , ISalon
{
    

    public SalonRepository(InsidenciasContext context) :base(context)
    {
        
    }
}