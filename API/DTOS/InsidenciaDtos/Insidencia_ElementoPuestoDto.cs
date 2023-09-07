using API.DTOS.ElementoPuestoDtos;

namespace API.DTOS.InsidenciaDtos;

public class Insidencia_ElementoPuestoDto
{
    public DateTime   FechaReporte { get; set; }
    public string Descripcion { get; set; }
    public int  PersonaId { get; set; }
   
    public int Tipo_GravedadId { get; set; }
    public int CategoriaId { get; set; }
   
    public List<ElementoPuestoIdDto> ? ElementoPuestos { get; set; }
}
