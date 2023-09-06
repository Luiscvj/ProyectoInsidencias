public class Arl
{
    public int ArlID { get; set; }
    public string Nombre { get; set; }
    public List<Usuario> Usuarios { get; set; }
    public List<TipoContacto> TipoContactos { get; set; }
    public List<ContactoArl> ContactosArl{ get; set; }
}