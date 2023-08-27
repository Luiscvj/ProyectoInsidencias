public class TipoContacto
{
    public int TipoContactoID { get; set; }
    public string NombreTipo { get; set; }
    public List<Arl> Arls { get; set; }
    public List<Eps> Epss { get; set; }
    public List<ContactoArl> ContactosArl { get; set; }
    public List<ContactoEps> ContactosEps { get; set; }

}