using AutoMapper;
using Controllers.DTOS;

namespace API.Profiles;


public class  MappingProfiles : Profile
{
   public MappingProfiles()
   {
      CreateMap<PaisDto,Pais>().ReverseMap();
   } 
}