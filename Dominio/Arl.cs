public class Arl
{
    public int ArlID { get; set; }
    public string Nombre { get; set; }
    public List<Trainer> Trainers { get; set; }
    public List<TipoContacto> TipoContactos { get; set; }
    public List<ContactoArl> ContactosArl{ get; set; }
}