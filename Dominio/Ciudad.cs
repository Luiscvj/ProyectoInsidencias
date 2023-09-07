public class Ciudad
{
    public int CiudadId { get; set; }
    public string  Nombre { get; set; }
    public List<Persona>? Personas { get; set; }
    public int DepartamentoId { get; set; }
    public Departamento Departamento { get; set; }
}