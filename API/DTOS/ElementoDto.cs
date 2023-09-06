namespace API.DTOS;

public class ElementoDto
{
    public string NombreElemento { get; set; }
    public string Descripcion { get; set; }
    public int CategoriaId { get; set; }
    public Categoria Categoria { get; set; }
}