using API.DTOS;
using API.Helpers;
using AutoMapper;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;


public class DepartamentoController : BaseApiController
{
    public DepartamentoController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }


   
    [HttpPost("AddDepartamento")]
    [Authorize(Roles ="Gerente,Administrador")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult> Add(DepartamentoCiudadDto departamentoD)
    {
        Departamento dep = _mapper.Map<Departamento>(departamentoD);

        _unitOfWork.Departamentos.Add(dep);
        int num = await _unitOfWork.SaveChanges();

        return CreatedAtAction(nameof(Add),new {id = dep.DepartamentoID},dep);
    }


    [HttpPost("AddRangeDep")]
    [Authorize(Roles ="Gerente,Administrador")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult> AddRange(IEnumerable<DepartamentoCiudadDto> depDto)
    {
            if(depDto == null)
                return BadRequest();

            IEnumerable<Departamento> deps = _mapper.Map<IEnumerable<Departamento>>(depDto);

            _unitOfWork.Departamentos.AddRange(deps);
            int num = await _unitOfWork.SaveChanges();

            foreach(Departamento d in deps)
            {
                CreatedAtAction(nameof(AddRange), new {id = d.DepartamentoID},d);

            }

            return Ok();
    }

    [HttpGet("GetByID/{id}")]
    [Authorize(Roles ="Gerente,Administrador,Empleado,Trainer,Estudiante,Sin_Asignar")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<DepartamentoCiudadDto>> GetById(int id)
    {
           Departamento dep = await _unitOfWork.Departamentos.GetById(id);
           
           return _mapper.Map<DepartamentoCiudadDto>(dep);
    }


    [HttpGet("GetAll")]
    [MapToApiVersion("1.1")]
    [Authorize(Roles ="Gerente,Administrador,Empleado,Trainer,Estudiante,Sin_Asignar")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]


    public async Task<ActionResult<Pager<DepartamentoCiudadDto>>> GetAll([FromQuery]Params depsParams)
    {   
        var  Departamentos =await _unitOfWork.Departamentos.GetAllAsync(depsParams.PageIndex,depsParams.PageSize,depsParams.Search);
        var lstDepartamentosDto =_mapper.Map<List<DepartamentoCiudadDto>>(Departamentos.registros);
      

        return  new Pager<DepartamentoCiudadDto>(lstDepartamentosDto,depsParams.Search,Departamentos.totalRegistros,depsParams.PageIndex,depsParams.PageSize);
    }

    [HttpGet("GetDepCities")]
    [MapToApiVersion("1.1")]
    [Authorize(Roles ="Gerente,Administrador")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Pager<DepartamentoCiudadDto>>> GetAllDeps([FromQuery]Params depsParams)
    {
        var deps = await _unitOfWork.Departamentos.GetAllAsync(depsParams.PageIndex,depsParams.PageSize,depsParams.Search);
        var lstDeps = _mapper.Map<List<DepartamentoCiudadDto>>(deps.registros);

        return new Pager<DepartamentoCiudadDto>(lstDeps,depsParams.Search,deps.totalRegistros,depsParams.PageIndex,depsParams.PageSize);
    }


   [HttpDelete("{id}")]
   [Authorize(Roles ="Gerente,Administrador")]
   [ProducesResponseType(StatusCodes.Status200OK)]
   [ProducesResponseType(StatusCodes.Status400BadRequest)]

   public async Task<ActionResult> Delete(int id)
   {
        Departamento dep = await _unitOfWork.Departamentos.GetById(id);

        _unitOfWork.Departamentos.Remove(dep);
        int num = await _unitOfWork.SaveChanges();

        if(num == 0)
            return BadRequest();
        
        return NoContent();
   }

   [HttpPut("UpdateDep")]
   [Authorize(Roles ="Gerente,Administrador")]
   [ProducesResponseType(StatusCodes.Status200OK)]
   [ProducesResponseType(StatusCodes.Status400BadRequest)]

   public async Task<ActionResult<Departamento>> Update(int id,[FromBody]DepartamentoCiudadDto depDto)
   {
        Departamento dep = _mapper.Map<Departamento>(depDto);

        _unitOfWork.Departamentos.Update(dep);

        int num =await  _unitOfWork.SaveChanges();
        if (num == 0)
             return BadRequest();

        return dep ;
   }


}