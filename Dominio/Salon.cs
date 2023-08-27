public class Salon
{
    public int SalonID { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public int AreaId { get; set; }
    public Area Area { get; set; }
    public List<Puesto> Puestos { get; set; }

}