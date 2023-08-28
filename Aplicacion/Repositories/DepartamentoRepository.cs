using Dominio.Interfaces;

namespace Aplicacion.Repositories;


public class DepartamentoRepository : GenericRepository<Departamento> , IDepartamento
{
    

    public DepartamentoRepository(InsidenciasContext context): base(context)
    {
    }
}