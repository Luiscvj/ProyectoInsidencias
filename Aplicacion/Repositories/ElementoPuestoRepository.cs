using Dominio.Interfaces;

namespace Aplicacion.Repositories;

public class ElementoPuestoRepository : GenericRepository<ElementoPuesto>, IElementoPuesto
{
    public ElementoPuestoRepository(InsidenciasContext context) : base(context)
    {
        
    }
}