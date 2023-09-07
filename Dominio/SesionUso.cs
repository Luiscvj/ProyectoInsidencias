public class SesionUso
{
    public int PuestoID { get; set; }
    public Puesto Puesto { get; set; }
    public int  PersonaId { get; set; }
    public Persona Persona { get; set; }
    public DateTime  FechaInicio   { get; set; }
    public DateTime FechaCierre { get; set; }
}