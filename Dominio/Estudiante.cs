

public class Estudiante :Persona 
{
   public Genero Genero { get; set; }
   public Ciudad Ciudad { get; set; }
   public TipoPersona  TipoPersona  { get; set; }
   public Direccion Direccion { get; set; }
   public List<Puesto>  Puestos { get; set; }
   public List<SesionUso> SesionUsos { get; set; }
}

