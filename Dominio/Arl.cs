public class Arl
{
    public int ArlID { get; set; }
    public string Nombre { get; set; }
    public List<Persona>? Personas { get; set; }
    public List<TipoContacto> TipoContactos { get; set; }
    public List<ContactoArl> ContactosArl{ get; set; }
}