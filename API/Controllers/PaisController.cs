using API.Helpers;
using API.Helpers;
using AutoMapper;
using Controllers.DTOS;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace API.Controllers;


public class PaisController : BaseApiController
{
    public PaisController(IUnitOfWork _unitOfWork, IMapper _mapper) : base(_unitOfWork,_mapper)
    {

    }


    [HttpPost("Add")]
    [MapToApiVersion("1.0")]
    [Authorize(Roles = "Administrador,Gerente")]
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
    [MapToApiVersion("1.0")]
    [Authorize(Roles = "Administrador,Gerente")]
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
    [MapToApiVersion("1.0")]
    [Authorize(Roles = "Administrador,Gerente,Trainer,Empleado,Estudiante,Sin_Asignar")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]


    public async Task<ActionResult<PaisDto>> GetById(int id)
    {
        Pais p = await _unitOfWork.Paises.GetById(id);

        return Ok(_mapper.Map<PaisDto>(p));
    }

    [HttpGet("GetAll")]
    [MapToApiVersion("1.0")]
    [Authorize(Roles = "Administrador,Gerente")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Pager<PaisDto>>> GetAll([FromQuery] Params paisParams)
    {   
        
        var  paises =await _unitOfWork.Paises.GetAllAsync(paisParams.PageIndex,paisParams.PageSize,paisParams.Search);
        var lstPaisesDto =_mapper.Map<List<PaisDto>>(paises.registros);
      

        return  new Pager<PaisDto>(lstPaisesDto,paisParams.Search,paises.totalRegistros,paisParams.PageIndex,paisParams.PageSize);
    }


    [HttpDelete("Delete/{id}")]
    [MapToApiVersion("1.0")]
    [Authorize(Roles = "Administrador,Gerente")]
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

    [HttpPut("{id}")]
    [MapToApiVersion("1.0")]
    [Authorize(Roles = "Administrador,Gerente")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<PaisDto>> PutPais(int id ,[FromBody]PaisDto pais)
    {
        if (pais == null)
            return BadRequest();
        
        Pais p = _mapper.Map<Pais>(pais);
        _unitOfWork.Paises.Update(p);
        int num = await _unitOfWork.SaveChanges();

        if(num == 0 )
            return BadRequest();
        

        return  Ok(_mapper.Map<PaisDto>(p));



    }
}