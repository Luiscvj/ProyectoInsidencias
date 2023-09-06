using API.DTOS;
using AutoMapper;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class CiudadController : BaseApiController
{
    public CiudadController(IUnitOfWork _unitOfWork, IMapper _mapper) : base(_unitOfWork, _mapper)
    {

    }

    [HttpPost("AddCiudad")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult> Add(CiudadDto CiudadD)
    {
        Ciudad ciud = _mapper.Map<Ciudad>(CiudadD);

        _unitOfWork.Ciudades.Add(ciud);
        int num = await _unitOfWork.SaveChanges();

        return CreatedAtAction(nameof(Add),new {id = ciud.CiudadId},ciud);
    }


    [HttpPost("AddRangeCiudad")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult> AddRange(IEnumerable<CiudadDto> ciudadD)
    {
            if(ciudadD == null)
                return BadRequest();

            IEnumerable<Ciudad> ciudades = _mapper.Map<IEnumerable<Ciudad>>(ciudadD);

            _unitOfWork.Ciudades.AddRange(ciudades);
            int num = await _unitOfWork.SaveChanges();

            foreach(Ciudad d in ciudades)
            {
                CreatedAtAction(nameof(AddRange), new {id = d.CiudadId},d);

            }

            return Ok();
    }

    [HttpGet("GetByID/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<CiudadDto>> GetById(int id)
    {
           Ciudad ciudad = await _unitOfWork.Ciudades.GetById(id);
           
           return _mapper.Map<CiudadDto>(ciudad);
    }


    [HttpGet("GetAll")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]


    public async Task<IEnumerable<CiudadDto>> GetAll()
    {   
        IEnumerable<Ciudad> cities = await _unitOfWork.Ciudades.GetAll();

        return _mapper.Map<IEnumerable<CiudadDto>>(cities);
    }

   /*  [HttpGet("GetciudadCities")]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<IEnumerable<CiudadDto>> GetAllciudades()
    {
        IEnumerable<Ciudad> cities =await  _unitOfWork.Ciudades.GetAll();
        return _mapper.Map<IEnumerable<CiudadDto>>(cities);
      
    } */


   [HttpDelete("{id}")]
   [ProducesResponseType(StatusCodes.Status200OK)]
   [ProducesResponseType(StatusCodes.Status400BadRequest)]

   public async Task<ActionResult> Delete(int id)
   {
        Ciudad ciudad = await _unitOfWork.Ciudades.GetById(id);

        _unitOfWork.Ciudades.Remove(ciudad);
        int num = await _unitOfWork.SaveChanges();

        if(num == 0)
            return BadRequest();
        
        return NoContent();
   }

   [HttpPut("UpdateCiudad")]
   [ProducesResponseType(StatusCodes.Status200OK)]
   [ProducesResponseType(StatusCodes.Status400BadRequest)]

   public async Task<ActionResult<Ciudad>> Update(int id,[FromBody]CiudadDto ciudadD)
   {
        Ciudad ciudad = _mapper.Map<Ciudad>(ciudadD);

        _unitOfWork.Ciudades.Update(ciudad);

        int num =await  _unitOfWork.SaveChanges();
        if (num == 0)
             return BadRequest();

        return ciudad ;
   }


}