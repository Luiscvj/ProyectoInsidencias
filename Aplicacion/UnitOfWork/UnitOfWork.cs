using Aplicacion.Repositories;
using Dominio.Interfaces;

namespace Aplicacion.UnitOfWork;

public class UnitOfWork : IUnitOfWork, IDisposable
{   
    private  AreaRepository  _Areas; 
    private  ArlRepository  _Arls; 
    private  CategoriaRepository  _Categorias; 
    private  CiudadRepository  _Ciudades;
    private  ContactoArlRepository  _ContactosArl;
    private  ContactoEpsRepository  _ContactosEps;
    private  DepartamentoRepository  _Departamentos;
    private  DireccionRepository  _Direcciones;
    private  ElementoRepository  _Elementos;
    private  ElementoPuestoRepository  _ElementoPuestos;
    private  EpsRepository  _Epss;
    private  EstudianteRepository  _Estudiantes;
    private  GeneroRepository  _Generos;
    private  InsidenciaRepository  _Insidencias;
    private  PaisRepository  _Paises;
    private  PuestoRepository  _Puestos;
    private  SalonRepository  _Salones;
    private  SesionUsoRepository  _SesionUsos;
    private  Tipo_GravedadRepository  _Tipos_Gravedad;
    private  TipoContactoRepository  _TipoContactos;
    private  TipoPersonaRepository  _TipoPersonas;
    private  TrainerRepository  _Trainers;

    private readonly InsidenciasContext _context;

    public UnitOfWork(InsidenciasContext context)
    {
        _context = context;
    }

    public IArea Areas 
    {
        get
        {
            if(_Areas == null)
            {
                _Areas = new AreaRepository(_context); 
           }
            return _Areas;
       }
    }

    public IArl Arls 
    {
        get
        {
            if(_Arls == null)
            {
                _Arls = new ArlRepository(_context);
            }
            return _Arls;
        }
    }

    public ICategoria Categorias 
    {
        get
        {
            if(_Categorias == null)
            {
                _Categorias = new CategoriaRepository(_context);
            }
            return _Categorias;
        }
    }

    public ICiudad Ciudades 
    {
        get
        {
            if(_Ciudades == null)
            {
                _Ciudades = new CiudadRepository(_context); 
            }
            return _Ciudades;
        }
    }

    public IContactoArl ContactosArl 
    {
        get
        {
            if(_ContactosArl == null)
            {
                _ContactosArl = new ContactoArlRepository(_context);
            }
            return _ContactosArl;
        }
    }

    public IContactoEps ContactosEps 
    {
        get
        {
            if(_ContactosEps == null)
            {
                _ContactosEps = new ContactoEpsRepository(_context);
            }
            return _ContactosEps;
        }
    }

    public IDepartamento Departamentos 
    {
        get
        {
            if(_Departamentos == null)
            {
                _Departamentos = new DepartamentoRepository(_context);
            }
            return _Departamentos;
        }
    }

    public IDireccion Direcciones 
    {
        get
        {
            if(_Direcciones == null)
            {
                _Direcciones = new DireccionRepository(_context);
            }
            return _Direcciones;
        }
    }

    public IElemento Elementos 
    {
        get
        {
            if(_Elementos == null)
            {
                _Elementos = new ElementoRepository(_context); 
            }
            return _Elementos;
        }
    }

    public IElementoPuesto ElementoPuestos 
    {
        get
        {
            if(_ElementoPuestos == null)
            {
                _ElementoPuestos = new ElementoPuestoRepository(_context);
            }
            return _ElementoPuestos;
        }
    }

    public IEps Epss 
    {
        get
        {
            if(_Epss == null)
            {
                _Epss = new EpsRepository(_context);
            } 
            return _Epss;
        }
    }

    public IEstudiante Estudiantes 
    {
        get
        {
            if(_Estudiantes == null)
            {
                _Estudiantes = new EstudianteRepository(_context);
            }
            return _Estudiantes;
        }
    }

    public IGenero Generos 
    {
        get
        {
            if(_Generos == null)
            {
                _Generos = new GeneroRepository(_context); 
            }
            return _Generos;
        }
    }

    public IInsidencia Insidencias 
    {
        get
        {
            if(_Insidencias == null)
            {
                _Insidencias = new InsidenciaRepository(_context);
            }
            return _Insidencias;
        }
    }

    public IPais Paises 
    {
        get
        {
            if(_Paises == null)
            {
                _Paises = new PaisRepository(_context);
            }
            return _Paises;
        }
    }

    public IPuesto Puestos 
    {
        get
        {
            if(_Puestos == null)
            {
                _Puestos = new PuestoRepository(_context); 
            }
            return _Puestos;
        }
    }

    public ISalon Salones 
    {
        get
        {
            if(_Salones == null)
            {
                _Salones = new SalonRepository(_context); 
            }
            return _Salones;
        }
    }

    public ISesionUso SesionUsos 
    {
        get
        {
            if(_SesionUsos == null)
            {
                _SesionUsos = new SesionUsoRepository(_context);
            }
            return _SesionUsos;
        }
    }

    public ITipo_Gravedad Tipos_Gravedad 
    {
        get
        {
            if(_Tipos_Gravedad == null)
            {
                _Tipos_Gravedad = new Tipo_GravedadRepository(_context);
            }
            return _Tipos_Gravedad;
        }
    }

    public ITipoContacto TiposContacto 
    {
        get
        {
            if(_TipoContactos == null)
            {
                _TipoContactos = new TipoContactoRepository(_context);
            }
            return _TipoContactos;
        }
    }

    public ITipoPersona TiposPersona 
    {
        get
        {
            if(_TipoPersonas == null)
            {
                _TipoPersonas = new TipoPersonaRepository(_context);
            }
            return _TipoPersonas;
        }
    }

    public ITrainer Trainers 
    {
        get
        {
            if(_Trainers == null)
            {
                _Trainers = new TrainerRepository(_context); 
            }
            return _Trainers;
        }
    }

    public async  Task<int> SaveChanges()
    {
        return await  _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}