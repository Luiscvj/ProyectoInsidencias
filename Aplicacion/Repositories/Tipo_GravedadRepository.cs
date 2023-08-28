using Dominio.Interfaces;

namespace Aplicacion.Repositories;

public class Tipo_GravedadRepository : GenericRepository<Tipo_Gravedad> , ITipo_Gravedad
{
    

    public Tipo_GravedadRepository(InsidenciasContext context) :base(context)
    {
       
    }
}