using AutoMapper;
using Controllers.DTOS;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class PaisController : BaseApiController
{
    public PaisController(IUnitOfWork _unitOfWork, IMapper _mapper) : base(_unitOfWork,_mapper)
    {

    }


    [HttpPost("Add")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult> Add(PaisDto entity)
    {
        Pais p = _mapper.Map<Pais>(entity);
        if(p == null)
        {
            return BadRequest();
        }

        _unitOfWork.Paises.Add(p);
        int num = await _unitOfWork.SaveChanges();

        if(num == 0)
        {
            return BadRequest();
        }

        return CreatedAtAction(nameof(Add), new {id = p.PaisID},p);
    }

    [HttpPost("AddRange")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult> AddPaises(IEnumerable<PaisDto> paisesDto)
    {
        IEnumerable<Pais> paises = _mapper.Map<IEnumerable<Pais>>(paisesDto);

        if(paises == null)
        {
            return BadRequest();
        }

        _unitOfWork.Paises.AddRange(paises);
        int num = await _unitOfWork.SaveChanges();

        if(num == 0)
        {
            return BadRequest();
        }

        foreach(Pais p in paises)
        {
            CreatedAtAction(nameof(AddPaises), new {id = p.PaisID},p);
        }
        return Ok();
    }
    [HttpGet("GetById/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]


    public async Task<ActionResult<PaisDto>> GetById(int id)
    {
        Pais p = await _unitOfWork.Paises.GetById(id);

        return Ok(_mapper.Map<PaisDto>(p));
    }

    [HttpGet("GetAll")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<PaisDto>>> GetAll()
    {   IEnumerable<Pais> paises =await _unitOfWork.Paises.GetAll();

        IEnumerable<PaisDto> paisesDto =  _mapper.Map<IEnumerable<PaisDto>>(paises);

        return Ok(paisesDto);
    }

    [HttpDelete("Delete/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult> Delete(int id)
    {
        Pais p = await _unitOfWork.Paises.GetById(id);
        if(p == null)
        {
            return BadRequest();
        }
        _unitOfWork.Paises.Remove(p);
        int num = await _unitOfWork.SaveChanges();

        if(num == 0)
        {
            return BadRequest();
        }

        return NoContent();
    }
}