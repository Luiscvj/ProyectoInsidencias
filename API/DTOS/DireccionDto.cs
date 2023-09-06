namespace API.DTOS;

public class DireccionDto
{
    public string   TipoVia { get; set; }
    public int Numero { get; set; }
    public string   ? Letra { get; set; }
    public string ? SufijoCardinal { get; set; }
    public int NroViaSecundaria { get; set; }
    public string  ?SufijoCardinalSecundario { get; set; }
}