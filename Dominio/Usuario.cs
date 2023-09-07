
public class Usuario
{
    public int UsuarioId { get; set; }
    public string  Username { get; set; }
    public string  Password { get; set; }
    public string Email { get; set; }
    public ICollection<Rol> Roles { get; set; } = new HashSet<Rol>();
    public List<RolesUsuario> RolesUsuarios { get; set; }
    public int ?  usuarioDePersona { get; set; }
    public Persona ? Persona { get; set; }
    
     
    


}