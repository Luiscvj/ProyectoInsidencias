public class Puesto
{
    public int PuestoID { get; set; }
    public int SalonId { get; set; }
    public Salon Salon { get; set; }
    public List<Elemento> Elementos { get; set; }
    public List<Estudiante>  Estudiantes { get; set; }
    public List<SesionUso> SesionUsos { get; set; }
}