public class Eps
{
    public int EpsID { get; set; }
    public string Nombre { get; set; }
    public List<Usuario> Usuarios { get; set; }
    public List<TipoContacto> TipoContactos { get; set; }
    public List<ContactoEps> ContactosEps { get; set; }
}