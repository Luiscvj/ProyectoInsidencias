using API.DTOS;
using AutoMapper;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;


public class SalonController : BaseApiController
{
    public SalonController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }

     
    [HttpPost("AddSalon")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult> Add(SalonDto SalonD)
    {
        Salon salon = _mapper.Map<Salon>(SalonD);

        _unitOfWork.Salones.Add(salon);
        int num = await _unitOfWork.SaveChanges();

        return CreatedAtAction(nameof(Add),new {id = salon.SalonID},salon);
    }


    [HttpPost("AddRangeDep")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult> AddRange(IEnumerable<SalonDto> depDto)
    {
            if(depDto == null)
                return BadRequest();

            IEnumerable<Salon> salones = _mapper.Map<IEnumerable<Salon>>(depDto);

            _unitOfWork.Salones.AddRange(salones);
            int num = await _unitOfWork.SaveChanges();

            foreach(Salon d in salones)
            {
                CreatedAtAction(nameof(AddRange), new {id = d.SalonID},d);

            }

            return Ok();
    }

    [HttpGet("GetByID/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<SalonDto>> GetById(int id)
    {
           Salon salon = await _unitOfWork.Salones.GetById(id);
           
           return _mapper.Map<SalonDto>(salon);
    }


    [HttpGet("GetAll")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]


    public async Task<IEnumerable<SalonDto>> GetAll()
    {   
        IEnumerable<Salon> salon = await _unitOfWork.Salones.GetAll();

        return _mapper.Map<IEnumerable<SalonDto>>(salon);
    }

    [HttpGet("GetDepCities")]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<IEnumerable<SalonDto>> GetAllDSalon()
    {
        IEnumerable<Salon> salon =await  _unitOfWork.Salones.GetAll();
        return _mapper.Map<IEnumerable<SalonDto>>(salon);
      
    }


   [HttpDelete("{id}")]
   [ProducesResponseType(StatusCodes.Status200OK)]
   [ProducesResponseType(StatusCodes.Status400BadRequest)]

   public async Task<ActionResult> Delete(int id)
   {
        Salon salon = await _unitOfWork.Salones.GetById(id);

        _unitOfWork.Salones.Remove(salon);
        int num = await _unitOfWork.SaveChanges();

        if(num == 0)
            return BadRequest();
        
        return NoContent();
   }

   [HttpPut("UpdateDep")]
   [ProducesResponseType(StatusCodes.Status200OK)]
   [ProducesResponseType(StatusCodes.Status400BadRequest)]

   public async Task<ActionResult<Salon>> Update(int id,[FromBody]SalonDto depDto)
   {
        Salon salon = _mapper.Map<Salon>(depDto);

        _unitOfWork.Salones.Update(salon);

        int num =await  _unitOfWork.SaveChanges();
        if (num == 0)
             return BadRequest();

        return salon ;
   }


}