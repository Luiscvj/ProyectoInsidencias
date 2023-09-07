using System.ComponentModel.DataAnnotations;

namespace API.DTOS.ROLDTO;


public class AddRolDto
{
    [Required]
    public string Username  { get; set; }
     [Required]
    public string Password { get; set; }
     [Required]
    public string Rol { get; set; }
}