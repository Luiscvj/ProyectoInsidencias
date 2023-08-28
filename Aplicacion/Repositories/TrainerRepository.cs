using Dominio.Interfaces;

namespace Aplicacion.Repositories;

public class TrainerRepository : GenericRepository<Trainer> , ITrainer
{
    

    public TrainerRepository(InsidenciasContext context) :base(context)
    {
        
    }
}