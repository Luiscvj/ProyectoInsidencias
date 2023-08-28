using Dominio.Interfaces;

namespace Aplicacion.Repositories;

public class EstudianteRepository : GenericRepository<Estudiante> , IEstudiante
{


    public EstudianteRepository(InsidenciasContext context) :base(context)
    {
        
    }
}