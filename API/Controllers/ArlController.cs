using API.DTOS;
using AutoMapper;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class ArlController : BaseApiController
{
    public ArlController(IUnitOfWork _unitOfWork,IMapper _mapper) : base(_unitOfWork,_mapper)
    {

    }


    [HttpPost("AddArl")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]


    public async Task<ActionResult> Add(ArlDto entity)
    {
        if(entity == null) 
            return BadRequest();

        Arl arl = _mapper.Map<Arl>(entity);
        _unitOfWork.Arls.Add(arl);
        int num = await _unitOfWork.SaveChanges();

        if( num == 0)
            return BadRequest();

        return Ok();
    }


    
    [HttpPost("AddRangeArl")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult> AddRange(IEnumerable<ArlDto> arlDto)
    {
            if(arlDto == null)
                return BadRequest();

            IEnumerable<Arl> Arls = _mapper.Map<IEnumerable<Arl>>(arlDto);

            _unitOfWork.Arls.AddRange(Arls);
            int num = await _unitOfWork.SaveChanges();

            foreach(Arl d in Arls)
            {
                CreatedAtAction(nameof(AddRange), new {id = d.ArlID},d);

            }

            return Ok();
    }

    [HttpGet("GetByID/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<ArlDto>> GetById(int id)
    {
           Arl Arl = await _unitOfWork.Arls.GetById(id);
           
           return _mapper.Map<ArlDto>(Arl);
    }


    [HttpGet("GetAll")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]


    public async Task<IEnumerable<ArlDto>> GetAll()
    {   
        IEnumerable<Arl> arls = await _unitOfWork.Arls.GetAll();

        return _mapper.Map<IEnumerable<ArlDto>>(arls);
    }

   /*  [HttpGet("GetArlarls")]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<IEnumerable<ArlDto>> GetAllArls()
    {
        IEnumerable<Arl> arls =await  _unitOfWork.Arls.GetAll();
        return _mapper.Map<IEnumerable<ArlDto>>(arls);
      
    } */


   [HttpDelete("{id}")]
   [ProducesResponseType(StatusCodes.Status200OK)]
   [ProducesResponseType(StatusCodes.Status400BadRequest)]

   public async Task<ActionResult> Delete(int id)
   {
        Arl arl = await _unitOfWork.Arls.GetById(id);

        _unitOfWork.Arls.Remove(arl);
        int num = await _unitOfWork.SaveChanges();

        if(num == 0)
            return BadRequest();
        
        return NoContent();
   }

   [HttpPut("UpdateArl")]
   [ProducesResponseType(StatusCodes.Status200OK)]
   [ProducesResponseType(StatusCodes.Status400BadRequest)]

   public async Task<ActionResult<Arl>> Update(int id,[FromBody]ArlDto ArlDto)
   {
        Arl arl = _mapper.Map<Arl>(ArlDto);

        _unitOfWork.Arls.Update(arl);

        int num =await  _unitOfWork.SaveChanges();
        if (num == 0)
             return BadRequest();

        return arl ;
   }

}