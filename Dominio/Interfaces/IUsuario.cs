namespace Dominio.Interfaces;


public interface  IUsuario : IGenericRepository<Usuario>
{
    

    Task<Usuario> GetByUserAsync(string username);
}