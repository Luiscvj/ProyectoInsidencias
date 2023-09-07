using Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Aplicacion.Repositories;

public class UsuarioRepository : GenericRepository<Usuario> , IUsuario
{
        private readonly InsidenciasContext _context;

    public UsuarioRepository(InsidenciasContext context) :base(context)
    {
        _context   = context;
    }

    public async Task<Usuario> GetByUserAsync(string username)
    {
            return  await  _context.Usuarios.Include(u =>u.Roles)
                                         .FirstOrDefaultAsync(u => u.Username.ToLower() == username.ToLower());                                   
    }
}