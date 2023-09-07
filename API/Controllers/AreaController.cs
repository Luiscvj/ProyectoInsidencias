using API.Helpers;
using AutoMapper;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class AreaController : BaseApiController
{
    public AreaController(IUnitOfWork _unitOfWork, IMapper _mapper) : base(_unitOfWork,_mapper)
    {

    }

    [HttpPost("AddArea")]
    [Authorize(Roles = "Administrador,Gerente")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult> Add(AreaDto areaD)
    {
        if(areaD == null)
        {
            return BadRequest();
        }

        Area area = _mapper.Map<Area>(areaD);
        _unitOfWork.Areas.Add(area);
        int num = await _unitOfWork.SaveChanges();

        if( num == 0)
        {
            return BadRequest();
        }

        return CreatedAtAction(nameof(Add),new {id = area.AreaID},area);
    }

    [HttpPost("AddRangeAreas")]
    [Authorize(Roles = "Administrador,Gerente")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult> AddRange(IEnumerable<AreaDto> areasDto)
    {   
        if(areasDto == null)
            return BadRequest();
        IEnumerable<Area> areas = _mapper.Map<IEnumerable<Area>>(areasDto);
        _unitOfWork.Areas.AddRange(areas);
        int num = await _unitOfWork.SaveChanges();

        if(num == 0)
            return BadRequest();

        foreach(Area a in areas)
        {
            CreatedAtAction(nameof(AddRange),new {Id = a.AreaID},a);
        }

        return Ok();
        
    }

    [HttpGet("GetById/{id}")]
    [Authorize(Roles = "Estudiante,Trainer,Administrador,Gerente")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public  async Task<ActionResult<AreaDto>> GetById(int id)
    {
        Area area = await _unitOfWork.Areas.GetById(id);
        return _mapper.Map<AreaDto>(area);
    }
    [HttpGet("GetAll")]
    [MapToApiVersion("1.1")]
    [Authorize(Roles = "Estudiante,Trainer,Administrador,Gerente")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]


    public async Task<ActionResult<Pager<AreaDto>>> GetAll([FromQuery]Params areaParams)
    {
         var  Areas =await _unitOfWork.Areas.GetAllAsync(areaParams.PageIndex,areaParams.PageSize,areaParams.Search);
        var lstAreasDto =_mapper.Map<List<AreaDto>>(Areas.registros);
      

        return  new Pager<AreaDto>(lstAreasDto,areaParams.Search,Areas.totalRegistros,areaParams.PageIndex,areaParams.PageSize);
    }


  

    [HttpDelete("Delete/{id}")]
    [Authorize(Roles = "Administrador,Gerente")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult> Delete(int id)
    {
        Area a = await _unitOfWork.Areas.GetById(id);
        _unitOfWork.Areas.Remove(a);

        int num = await  _unitOfWork.SaveChanges();

        if(num == 0 )
             return BadRequest();

        return NoContent();
    }

    [HttpPut("UpdateArea")]
    [Authorize(Roles = "Administrador,Gerente")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult> Update(int id, [FromBody]AreaDto areaD)
    {   
        if(areaD == null )
            return BadRequest();
            
        Area a = _mapper.Map<Area>(areaD);
        _unitOfWork.Areas.Update(a);

        int num = await  _unitOfWork.SaveChanges();
        if(num == 0)
            return BadRequest();
        
        return Ok();
    }
}