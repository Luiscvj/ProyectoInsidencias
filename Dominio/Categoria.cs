public class Categoria
{
    public int CategoriaID { get; set; }
    public string TipoCategoria { get; set; }
    public string Descripcion { get; set; }
    public List<Elemento> Elementos { get; set; }
    public List<Insidencia> Insidencias { get; set; }

}