using Dominio.Interfaces;

namespace Aplicacion.Repositories;


public class CategoriaRepository : GenericRepository<Categoria> , ICategoria
{


    public CategoriaRepository(InsidenciasContext context): base(context)
    {
        
    }
}