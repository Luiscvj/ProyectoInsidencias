namespace Dominio.Interfaces;

public interface IUnitOfWork
{
    IArea Areas { get; }
    IArl Arls { get; }
    ICategoria Categorias { get; }
    ICiudad Ciudades { get; }
    IContactoArl ContactosArl { get; }
    IContactoEps ContactosEps { get; }
    IDepartamento Departamentos { get; }
    IDireccion Direcciones { get; }
    IElemento Elementos { get; }
    IElementoPuesto ElementoPuestos { get; }
    IEps Epss { get; }
    IEstudiante Estudiantes { get; }
    IGenero Generos { get; }
    IInsidencia Insidencias { get; }
    IPais Paises { get; }
    IPuesto Puestos { get; }
    ISalon Salones { get; }
    ISesionUso SesionUsos  { get; }
    ITipo_Gravedad Tipos_Gravedad { get; }
    ITipoContacto TiposContacto { get; }
    ITipoPersona TiposPersona { get; }
    ITrainer Trainers { get; }
}