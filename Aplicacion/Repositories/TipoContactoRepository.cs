using Dominio.Interfaces;

namespace Aplicacion.Repositories;

public class TipoContactoRepository : GenericRepository<TipoContacto> , ITipoContacto
{
   

    public TipoContactoRepository(InsidenciasContext context) :base(context)
    {
       
    }
}