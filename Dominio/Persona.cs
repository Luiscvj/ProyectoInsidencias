public class Persona 
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public int GeneroId { get; set; }
    public Genero? Genero { get; set; } = null;
   
    public int CiudadId { get; set; } 

    public Ciudad? Ciudad { get; set; }= null;
   
    public int DireccionId { get; set; }
    public Direccion? Direccion { get; set; } = null;
    public int ?ArlId   { get; set; }
    public Arl ? Arl  { get; set; }= null;
    public int ?EpsId { get; set; }
    public Eps? Eps { get; set; } = null;
    public List<Insidencia> Insidencias { get; set; }
    public List<Puesto> Puestos  { get; set; }
    public List<SesionUso> SesionUsos  { get; set; }

    public Usuario Usuario  { get; set; }


}