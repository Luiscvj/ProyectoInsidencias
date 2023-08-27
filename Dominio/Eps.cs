public class Eps
{
    public int EpsID { get; set; }
    public string Nombre { get; set; }
    public List<Trainer>    Trainers { get; set; }
    public List<TipoContacto> TipoContactos { get; set; }
    public List<ContactoEps> ContactosEps { get; set; }
}