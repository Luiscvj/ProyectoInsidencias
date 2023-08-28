using Dominio.Interfaces;

namespace Aplicacion.Repositories;

public class GeneroRepository : GenericRepository<Genero> , IGenero
{
    

    public GeneroRepository(InsidenciasContext context) :base(context)
    {
        
    }
}