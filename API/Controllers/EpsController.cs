using API.DTOS;
using AutoMapper;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class EpsController : BaseApiController
{
    public EpsController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }

     
    [HttpPost("AddEps")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult> Add(EpsDto EpsD)
    {
        Eps e = _mapper.Map<Eps>(EpsD);

        _unitOfWork.Epss.Add(e);
        int num = await _unitOfWork.SaveChanges();

        return CreatedAtAction(nameof(Add),new {id = e.EpsID},e);
    }


    [HttpPost("AddRangeEps")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult> AddRange(IEnumerable<EpsDto> depDto)
    {
            if(depDto == null)
                return BadRequest();

            IEnumerable<Eps> e = _mapper.Map<IEnumerable<Eps>>(depDto);

            _unitOfWork.Epss.AddRange(e);
            int num = await _unitOfWork.SaveChanges();

            foreach(Eps d in e)
            {
                CreatedAtAction(nameof(AddRange), new {id = d.EpsID},d);

            }

            return Ok();
    }

    [HttpGet("GetByID/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<EpsDto>> GetById(int id)
    {
           Eps e = await _unitOfWork.Epss.GetById(id);
           
           return _mapper.Map<EpsDto>(e);
    }


    [HttpGet("GetAll")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]


    public async Task<IEnumerable<EpsDto>> GetAll()
    {   
        IEnumerable<Eps> e = await _unitOfWork.Epss.GetAll();

        return _mapper.Map<IEnumerable<EpsDto>>(e);
    }

    [HttpGet("GetDepCities")]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<IEnumerable<EpsDto>> GetAllDeps()
    {
        IEnumerable<Eps> e =await  _unitOfWork.Epss.GetAll();
        return _mapper.Map<IEnumerable<EpsDto>>(e);
      
    }


   [HttpDelete("{id}")]
   [ProducesResponseType(StatusCodes.Status200OK)]
   [ProducesResponseType(StatusCodes.Status400BadRequest)]

   public async Task<ActionResult> Delete(int id)
   {
        Eps e = await _unitOfWork.Epss.GetById(id);

        _unitOfWork.Epss.Remove(e);
        int num = await _unitOfWork.SaveChanges();

        if(num == 0)
            return BadRequest();
        
        return NoContent();
   }

   [HttpPut("UpdateEps")]
   [ProducesResponseType(StatusCodes.Status200OK)]
   [ProducesResponseType(StatusCodes.Status400BadRequest)]

   public async Task<ActionResult<Eps>> Update(int id,[FromBody]EpsDto depDto)
   {
        Eps e = _mapper.Map<Eps>(depDto);

        _unitOfWork.Epss.Update(e);

        int num =await  _unitOfWork.SaveChanges();
        if (num == 0)
             return BadRequest();

        return e ;
   }
}