using API.Controllers;
using API.DTOS;
using API.DTOS.ElementoPuestoDtos;
using API.DTOS.InsidenciaDtos;
using API.DTOS.ROLDTO;
using AutoMapper;
using Controllers.DTOS;

namespace API.Profiles;


public class  MappingProfiles : Profile
{
   public MappingProfiles()
   {
      CreateMap<PaisDto,Pais>().ReverseMap();
      CreateMap<AreaDto,Area>().ReverseMap();
      CreateMap<TipoContacto,TipoContactoDto>().ReverseMap();
      CreateMap<ContactoArl,ContactoArlDto>().ReverseMap();
      CreateMap<Arl,ArlDto>().ReverseMap();
      CreateMap<Departamento,DepartamentoDto>().ReverseMap();
      CreateMap<Ciudad,CiudadDto>().ReverseMap();
      CreateMap<Departamento,DepartamentoCiudadDto>().ReverseMap();
      CreateMap<Categoria,CategoriaDto>().ReverseMap();
      CreateMap<Direccion,DireccionDto>().ReverseMap();
      CreateMap<Elemento,ElementoDto>().ReverseMap(); 
      CreateMap<Eps,EpsDto>().ReverseMap();
      CreateMap<Genero,GeneroDto>().ReverseMap();
      CreateMap<Salon,SalonDto>().ReverseMap();
      CreateMap<Rol,RolDto>().ReverseMap();
      CreateMap<SesionUso,SesionUsoDto>().ReverseMap();
      CreateMap<ContactoEps,ContactoEpsDto>().ReverseMap();
      CreateMap<ElementoPuesto, ElementoPuestoDto>().ReverseMap();
      CreateMap<ElementoPuesto,ElementoPuestoIdDto>().ReverseMap();
      CreateMap<TipoGravedadDto, TipoGravedadDto>().ReverseMap();
      CreateMap<Puesto,Puesto_Dto>().ReverseMap();
      CreateMap<Insidencia, Insidencia_ElementoPuestoDto>().ReverseMap();
      CreateMap<Insidencia, InsidenciaDto>().ReverseMap();
      
   } 
}