

using System.Reflection;
using Microsoft.EntityFrameworkCore;

public class InsidenciasContext : DbContext
{
    public InsidenciasContext(DbContextOptions<InsidenciasContext>  options ) : base(options)
    {

    }

    public  DbSet<Area> Areas  {get; set; }
    public  DbSet<Arl> Arls  {get; set; }
    public  DbSet<Categoria> Categorias  {get; set; }
    public  DbSet<Ciudad> Ciudades  {get; set; }
    public  DbSet<ContactoArl> ContactosArl  {get; set; }
    public  DbSet<ContactoEps> ContactosEps  {get; set; }
    public  DbSet<Departamento> Departamentos  {get; set; }
    public  DbSet<Direccion> Direcciones  {get; set; }
    public  DbSet<Elemento> Elementos  {get; set; }
    public  DbSet<ElementoPuesto> ElementosPuestos {get; set; }
    public  DbSet<Eps> Epss  {get; set; }
   
    public DbSet<Genero> Generos { get; set; }
    public DbSet<Insidencia> Insidencias { get; set; }
    public DbSet<Pais> Paises { get; set; }
    public DbSet<Puesto> Puestos { get; set; }
    public DbSet<Salon> Salones { get; set; }
    public DbSet<SesionUso> SesionesUso { get; set; }
    public DbSet<Tipo_Gravedad> Tipos_Gravedad { get; set; }
    public DbSet<TipoContacto> TipoContactos { get; set; }
    public DbSet<Rol> Roles { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }



    
  

   protected override void ConfigureConventions(ModelConfigurationBuilder modelBuilder)
   {
    modelBuilder.Properties<string>().HaveMaxLength(150);
   }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}