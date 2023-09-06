public class Rol
{//Rol
    public int RolId { get; set; }
    public string TipoRol { get; set; }
    public string Descripcion { get; set; }
 
    public List<Usuario> Usuarios { get; set; }
    public List<RolesUsuario> RolesUsuarios { get; set; }
    
}