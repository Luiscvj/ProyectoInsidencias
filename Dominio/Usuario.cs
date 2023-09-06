
public class Usuario
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string  Username { get; set; }
    public string  Password { get; set; }
    public string Email { get; set; }
    public int GeneroId { get; set; }
 
    public Genero Genero { get; set; }
   
    public int CiudadId { get; set; }

    public Ciudad Ciudad { get; set; }
   
    public int DireccionId { get; set; }
    public Direccion Direccion { get; set; }
    public int ArlId   { get; set; }
    public Arl Arl { get; set; }
    public int EpsId { get; set; }
    public Eps Eps { get; set; }
      
    
  
  
    public List<Insidencia> Insidencias { get; set; }
    public List<Rol> Roles { get; set; }
    public List<RolesUsuario> RolesUsuarios { get; set; }
    public List<Puesto> Puestos  { get; set; }
    public List<SesionUso> SesionUsos  { get; set; }
     
    


}