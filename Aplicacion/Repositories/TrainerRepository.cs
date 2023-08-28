using Dominio.Interfaces;

namespace Aplicacion.Repositories;

public class TrainerRepository : GenericRepository<Trainer> , ITrainer
{
    protected readonly InsidenciasContext _context;

    public TrainerRepository(InsidenciasContext context) :base(context)
    {
        _context = context;
    }
}