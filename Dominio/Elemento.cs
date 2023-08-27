public class Elemento
{
    public int ElementoID { get; set; }
    public string NombreElemento { get; set; }
    public string Descripcion { get; set; }
    public int CategoriaId { get; set; }
    public Categoria Categoria { get; set; }
    public List<Puesto> Puestos { get; set; }
}