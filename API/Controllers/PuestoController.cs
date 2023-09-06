using API.DTOS;
using AutoMapper;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;


public class PuestoController : BaseApiController
{
    public PuestoController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }

      [HttpPost("AddPuesto")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult> Add(PuestoDto PuestoD)
    {
        Puesto puesto = _mapper.Map<Puesto>(PuestoD);

        _unitOfWork.Puestos.Add(puesto);
        int num = await _unitOfWork.SaveChanges();

        return CreatedAtAction(nameof(Add),new {id = puesto.PuestoID},puesto);
    }


    [HttpPost("AddRangePuesto")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult> AddRange(IEnumerable<PuestoDto> puestoDto)
    {
            if(puestoDto == null)
                return BadRequest();

            IEnumerable<Puesto> puestos = _mapper.Map<IEnumerable<Puesto>>(puestoDto);

            _unitOfWork.Puestos.AddRange(puestos);
            int num = await _unitOfWork.SaveChanges();

            foreach(Puesto d in puestos)
            {
                CreatedAtAction(nameof(AddRange), new {id = d.PuestoID},d);

            }

            return Ok();
    }

    [HttpGet("GetByID/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<PuestoDto>> GetById(int id)
    {
           Puesto puesto = await _unitOfWork.Puestos.GetById(id);
           
           return _mapper.Map<PuestoDto>(puesto);
    }


    [HttpGet("GetAll")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]


    public async Task<IEnumerable<PuestoDto>> GetAll()
    {   
        IEnumerable<Puesto> puesto = await _unitOfWork.Puestos.GetAll();

        return _mapper.Map<IEnumerable<PuestoDto>>(puesto);
    }

    [HttpGet("GetDepCities")]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<IEnumerable<PuestoDto>> GetAllDPuesto()
    {
        IEnumerable<Puesto> puesto =await  _unitOfWork.Puestos.GetAll();
        return _mapper.Map<IEnumerable<PuestoDto>>(puesto);
      
    }


   [HttpDelete("{id}")]
   [ProducesResponseType(StatusCodes.Status200OK)]
   [ProducesResponseType(StatusCodes.Status400BadRequest)]

   public async Task<ActionResult> Delete(int id)
   {
        Puesto puesto = await _unitOfWork.Puestos.GetById(id);

        _unitOfWork.Puestos.Remove(puesto);
        int num = await _unitOfWork.SaveChanges();

        if(num == 0)
            return BadRequest();
        
        return NoContent();
   }

   [HttpPut("UpdatePuesto")]
   [ProducesResponseType(StatusCodes.Status200OK)]
   [ProducesResponseType(StatusCodes.Status400BadRequest)]

   public async Task<ActionResult<Puesto>> Update(int id,[FromBody]PuestoDto puestoDto)
   {
        Puesto puesto = _mapper.Map<Puesto>(puestoDto);

        _unitOfWork.Puestos.Update(puesto);

        int num =await  _unitOfWork.SaveChanges();
        if (num == 0)
             return BadRequest();

        return puesto ;
   }

}