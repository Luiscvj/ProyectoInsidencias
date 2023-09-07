using API.DTOS.InsidenciaDtos;
using API.Helpers;
using AutoMapper;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;


public class Insidencias : BaseApiController
{   
    protected readonly IUnitOfWork _unitOfWork;
    protected readonly IMapper _mapper;
    public Insidencias(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    
    [HttpPost("AddInsidencia")]
    [Authorize(Roles = "Administrador,Gerente")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult> Add(Insidencia_ElementoPuestoDto InsidenciaD)
    {
        if(InsidenciaD == null)
        {
            return BadRequest();
        }

        Insidencia Insidencia = _mapper.Map<Insidencia>(InsidenciaD);
        _unitOfWork.Insidencias.Add(Insidencia);
        int num = await _unitOfWork.SaveChanges();

        if( num == 0)
        {
            return BadRequest();
        }

        return CreatedAtAction(nameof(Add),new {id = Insidencia.InsidenciaID},Insidencia);
    }

    [HttpPost("AddRangeInsidencias")]
    [Authorize(Roles = "Administrador,Gerente")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult> AddRange(IEnumerable<Insidencia_ElementoPuestoDto> InsidenciasDto)
    {   
        if(InsidenciasDto == null)
            return BadRequest();
        IEnumerable<Insidencia> Insidencias = _mapper.Map<IEnumerable<Insidencia>>(InsidenciasDto);
        _unitOfWork.Insidencias.AddRange(Insidencias);
        int num = await _unitOfWork.SaveChanges();

        if(num == 0)
            return BadRequest();

        foreach(Insidencia a in Insidencias)
        {
            CreatedAtAction(nameof(AddRange),new {Id = a.InsidenciaID},a);
        }

        return Ok();
        
    }

    [HttpGet("GetById/{id}")]
    [Authorize(Roles = "Estudiante,Trainer,Administrador,Gerente")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public  async Task<ActionResult<Insidencia_ElementoPuestoDto>> GetById(int id)
    {
        Insidencia Insidencia = await _unitOfWork.Insidencias.GetById(id);
        return _mapper.Map<Insidencia_ElementoPuestoDto>(Insidencia);
    }


    [HttpGet("GetAllInsidencia")]
    [MapToApiVersion("1.1")]
    [Authorize(Roles = "Estudiante,Trainer,Administrador,Gerente")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]


    public async Task<ActionResult<Pager<InsidenciaDto>>> GetAll([FromQuery]Params InsidenciaParams)
    {
         var  Insidencias =await _unitOfWork.Insidencias.GetAllAsync(InsidenciaParams.PageIndex,InsidenciaParams.PageSize,InsidenciaParams.Search);
        var lstInsidenciasDto =_mapper.Map<List<InsidenciaDto>>(Insidencias.registros);
      

        return  new Pager<InsidenciaDto>(lstInsidenciasDto,InsidenciaParams.Search,Insidencias.totalRegistros,InsidenciaParams.PageIndex,InsidenciaParams.PageSize);
    }


    [HttpGet("GetAllInsidenciaElementoPuesto")]
    [MapToApiVersion("1.2")]
    [Authorize(Roles = "Estudiante,Trainer,Administrador,Gerente")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]


    public async Task<ActionResult<Pager<Insidencia_ElementoPuestoDto>>> GetAllInsidenciaELementoPuesto([FromQuery]Params InsidenciaParams)
    {
         var  Insidencias =await _unitOfWork.Insidencias.GetAllAsync(InsidenciaParams.PageIndex,InsidenciaParams.PageSize,InsidenciaParams.Search);
        var lstInsidenciasDto =_mapper.Map<List<Insidencia_ElementoPuestoDto>>(Insidencias.registros);
      

        return  new Pager<Insidencia_ElementoPuestoDto>(lstInsidenciasDto,InsidenciaParams.Search,Insidencias.totalRegistros,InsidenciaParams.PageIndex,InsidenciaParams.PageSize);
    }


  

    [HttpDelete("Delete/{id}")]
    [Authorize(Roles = "Administrador,Gerente")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult> Delete(int id)
    {
        Insidencia a = await _unitOfWork.Insidencias.GetById(id);
        _unitOfWork.Insidencias.Remove(a);

        int num = await  _unitOfWork.SaveChanges();

        if(num == 0 )
             return BadRequest();

        return NoContent();
    }

    [HttpPut("UpdateInsidencia")]
    [Authorize(Roles = "Administrador,Gerente")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult> Update(int id, [FromBody]Insidencia_ElementoPuestoDto InsidenciaD)
    {   
        if(InsidenciaD == null )
            return BadRequest();
            
        Insidencia a = _mapper.Map<Insidencia>(InsidenciaD);
        _unitOfWork.Insidencias.Update(a);

        int num = await  _unitOfWork.SaveChanges();
        if(num == 0)
            return BadRequest();
        
        return Ok();
    }

}