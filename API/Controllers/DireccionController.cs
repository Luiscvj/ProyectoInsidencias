using API.DTOS;
using AutoMapper;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class DireccionController : BaseApiController
{
    public DireccionController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }

    
    [HttpPost("AddDireccion")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult> Add(DireccionDto DireccionD)
    {
        Direccion dir = _mapper.Map<Direccion>(DireccionD);

        _unitOfWork.Direcciones.Add(dir);
        int num = await _unitOfWork.SaveChanges();

        return CreatedAtAction(nameof(Add),new {id = dir.DireccionID},dir);
    }


    [HttpPost("AddRangeDireccion")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult> AddRange(IEnumerable<DireccionDto> depDto)
    {
            if(depDto == null)
                return BadRequest();

            IEnumerable<Direccion> dir = _mapper.Map<IEnumerable<Direccion>>(depDto);

            _unitOfWork.Direcciones.AddRange(dir);
            int num = await _unitOfWork.SaveChanges();

            foreach(Direccion d in dir)
            {
                CreatedAtAction(nameof(AddRange), new {id = d.DireccionID},d);

            }

            return Ok();
    }

    [HttpGet("GetByID/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<DireccionDto>> GetById(int id)
    {
           Direccion dir = await _unitOfWork.Direcciones.GetById(id);
           
           return _mapper.Map<DireccionDto>(dir);
    }


    [HttpGet("GetAll")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]


    public async Task<IEnumerable<DireccionDto>> GetAll()
    {   
        IEnumerable<Direccion> dir = await _unitOfWork.Direcciones.GetAll();

        return _mapper.Map<IEnumerable<DireccionDto>>(dir);
    }

    [HttpGet("GetDepCities")]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<IEnumerable<DireccionDto>> GetAllDeps()
    {
        IEnumerable<Direccion> dir =await  _unitOfWork.Direcciones.GetAll();
        return _mapper.Map<IEnumerable<DireccionDto>>(dir);
      
    }


   [HttpDelete("{id}")]
   [ProducesResponseType(StatusCodes.Status200OK)]
   [ProducesResponseType(StatusCodes.Status400BadRequest)]

   public async Task<ActionResult> Delete(int id)
   {
        Direccion dir = await _unitOfWork.Direcciones.GetById(id);

        _unitOfWork.Direcciones.Remove(dir);
        int num = await _unitOfWork.SaveChanges();

        if(num == 0)
            return BadRequest();
        
        return NoContent();
   }

   [HttpPut("UpdateDireccion")]
   [ProducesResponseType(StatusCodes.Status200OK)]
   [ProducesResponseType(StatusCodes.Status400BadRequest)]

   public async Task<ActionResult<Direccion>> Update(int id,[FromBody]DireccionDto depDto)
   {
        Direccion dir = _mapper.Map<Direccion>(depDto);

        _unitOfWork.Direcciones.Update(dir);

        int num =await  _unitOfWork.SaveChanges();
        if (num == 0)
             return BadRequest();

        return dir ;
   }

}