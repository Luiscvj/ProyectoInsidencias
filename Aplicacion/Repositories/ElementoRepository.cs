using Dominio.Interfaces;

namespace Aplicacion.Repositories;


public class ElementoRepository : GenericRepository<Elemento> , IElemento
{
   

    public ElementoRepository(InsidenciasContext context): base(context)
    {
        
    }
}