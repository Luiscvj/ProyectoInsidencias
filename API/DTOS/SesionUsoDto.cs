namespace API.DTOS;

public class SesionUsoDto
{
    public int PuestoID { get; set; }
    public string  EstudianteId { get; set; }
    public DateTime  FechaInicio   { get; set; }
    public DateTime FechaCierre { get; set; }
}