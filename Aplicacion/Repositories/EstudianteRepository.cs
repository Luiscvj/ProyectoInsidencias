using Dominio.Interfaces;

namespace Aplicacion.Repositories;

public class EstudianteRepository : GenericRepository<Estudiante> , IEstudiante
{
    protected readonly InsidenciasContext _context;

    public EstudianteRepository(InsidenciasContext context) :base(context)
    {
        _context = context;
    }
}