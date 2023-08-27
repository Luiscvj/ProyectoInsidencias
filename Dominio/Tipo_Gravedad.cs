public class Tipo_Gravedad
{
    public int Tipo_GravedadID { get; set; }
    public string TipoGravedad { get; set; }
    public string ? Rubrica  { get; set; }
    public List<Insidencia> ?Insidencias { get; set; }

}