public class Trainer : Persona
{
  public int ArlId   { get; set; }
  public Arl Arl { get; set; }
  public int EpsId { get; set; }
  public Eps Eps { get; set; }
  public Genero Genero { get; set; }
  public Ciudad Ciudad { get; set; }
   public TipoPersona  TipoPersona  { get; set; }
  public Direccion Direccion { get; set; }
  public List<Insidencia> Insidencias { get; set; }
}