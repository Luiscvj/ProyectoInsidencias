namespace API.DTOS.InsidenciaDtos;


public class InsidenciaDto
{
    public int InsidenciaID { get; set; }
    public string Descripcion { get; set; }
    public int  PersonaId { get; set; }
    public int Tipo_GravedadId { get; set; }
   
    public int CategoriaId { get; set; }
}