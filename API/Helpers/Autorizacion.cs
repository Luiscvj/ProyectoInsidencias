namespace API.Helpers;



public class Autorizacion 
{
    public enum Roles
    {
        Trainer,
        Estudiante,    
        Empleado,
        Administrador,
        Sin_Asignar,
        Gerente

    }
    public const Roles rol_predeterminado = Roles.Sin_Asignar;

}