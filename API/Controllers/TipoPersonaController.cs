/* using API.DTOS;
using AutoMapper;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;


public class TipoPersonaController : BaseApiController
{
    public TipoPersonaController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }
    
    [HttpPost("AddTipoPersona")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult> Add(TipoPersonaDto tipoPersonaD)
    {
        TipoPersona tipoPersona = _mapper.Map<TipoPersona>(tipoPersonaD);
        _unitOfWork.TiposPersona.Add(tipoPersona);


        
        int num = await _unitOfWork.SaveChanges();

        return CreatedAtAction(nameof(Add),new {id = tipoPersona.TipoPersonaID},tipoPersona);
    }


    [HttpPost("AddRangeTipoPersona")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult> AddRange(IEnumerable<TipoPersonaDto> depDto)
    {
            if(depDto == null)
                return BadRequest();

            IEnumerable<TipoPersona> tipoPersonas = _mapper.Map<IEnumerable<TipoPersona>>(depDto);

            _unitOfWork.TiposPersona.AddRange(tipoPersonas);
            int num = await _unitOfWork.SaveChanges();

            foreach(TipoPersona d in tipoPersonas)
            {
                CreatedAtAction(nameof(AddRange), new {id = d.TipoPersonaID},d);

            }

            return Ok();
    }

    [HttpGet("GetByID/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<TipoPersonaDto>> GetById(int id)
    {
           TipoPersona tipoPersona = await _unitOfWork.TiposPersona.GetById(id);
           
           return _mapper.Map<TipoPersonaDto>(tipoPersona);
    }


    [HttpGet("GetAll")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]


    public async Task<IEnumerable<TipoPersonaDto>> GetAll()
    {   
        IEnumerable<TipoPersona> tipoPersona = await _unitOfWork.TiposPersona.GetAll();

        return _mapper.Map<IEnumerable<TipoPersonaDto>>(tipoPersona);
    } */

   /*  [HttpGet("GetElementoTipoPersona")]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<IEnumerable<TipoPersonaDto>> GetAllElementos()
    {
        IEnumerable<TipoPersona> tipoPersona =await  _unitOfWork.TiposPersona.GetAll();
        return _mapper.Map<IEnumerable<TipoPersonaDto>>(tipoPersona);
      
    } */

/* 
   [HttpDelete("{id}")]
   [ProducesResponseType(StatusCodes.Status200OK)]
   [ProducesResponseType(StatusCodes.Status400BadRequest)]

   public async Task<ActionResult> Delete(int id)
   {
        TipoPersona tipoPersona = await _unitOfWork.TiposPersona.GetById(id);

        _unitOfWork.TiposPersona.Remove(tipoPersona);
        int num = await _unitOfWork.SaveChanges();

        if(num == 0)
            return BadRequest();
        
        return NoContent();
   }

   [HttpPut("UpdateTipoPersona")]
   [ProducesResponseType(StatusCodes.Status200OK)]
   [ProducesResponseType(StatusCodes.Status400BadRequest)]

   public async Task<ActionResult<TipoPersona>> Update(int id,[FromBody]TipoPersonaDto tipoPersonaD)
   {
        TipoPersona tipoPersona = _mapper.Map<TipoPersona>(tipoPersonaD);

        _unitOfWork.TiposPersona.Update(tipoPersona);

        int num =await  _unitOfWork.SaveChanges();
        if (num == 0)
             return BadRequest();

        return tipoPersona ;
   }


} */