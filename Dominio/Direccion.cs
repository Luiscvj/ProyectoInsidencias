public class Direccion 
{
    public int DireccionID { get; set; }
    public string   TipoVia { get; set; }
    public int Numero { get; set; }
    public string   ?Letra { get; set; }
    public string ?SufijoCardinal { get; set; }
    public int NroViaSecundaria { get; set; }
    public string  ?SufijoCardinalSecundario { get; set; }
    public List<Trainer> Trainers { get; set; }
    public List<Estudiante> Estudiantes { get; set; }


}