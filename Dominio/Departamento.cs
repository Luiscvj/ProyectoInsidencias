public class Departamento 
{
    public int DepartamentoID { get; set; }
    public string NombreDep { get; set; }
    public int PaisId   { get; set; }
    public Pais Pais { get; set; }
    public List<Ciudad> Ciudades { get; set; }
}

