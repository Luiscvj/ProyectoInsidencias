using Dominio.Interfaces;

namespace Aplicacion.Repositories;

public class InsidenciaRepository : GenericRepository<Insidencia> , IInsidencia
{
   

    public InsidenciaRepository(InsidenciasContext context) :base(context)
    {
       
    }
}