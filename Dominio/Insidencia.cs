public class Insidencia
{
    public int InsidenciaID { get; set; }
    public DateTime   FechaReporte { get; set; }
    public string Descripcion { get; set; }
    public int  PersonaId { get; set; }
    public Persona Persona { get; set; }
    public int Tipo_GravedadId { get; set; }
    public Tipo_Gravedad Tipo_Gravedad { get; set; }
   
    public int CategoriaId { get; set; }
    public Categoria Categoria { get; set; }
    public List<ElementoPuesto> ? ElementoPuestos { get; set; }
}