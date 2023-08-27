public class ElementoPuesto
{
    public int Id { get; set; }
    public int ElementoId { get; set; }
    public int PuestoId { get; set; }
    public List<Insidencia> ? Insidencias{ get; set; }
}