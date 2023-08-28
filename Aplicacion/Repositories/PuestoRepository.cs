using Dominio.Interfaces;

namespace Aplicacion.Repositories;

public class PuestoRepository : GenericRepository<Puesto> , IPuesto
{


    public PuestoRepository(InsidenciasContext context) :base(context)
    {
       
    }
}