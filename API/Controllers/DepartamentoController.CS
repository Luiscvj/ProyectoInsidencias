using API.DTOS;
using AutoMapper;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;


public class DepartamentoController : BaseApiController
{
    public DepartamentoController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }


   
    [HttpPost("AddDepartamento")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult> Add(DepartamentoDto departamentoD)
    {
        Departamento dep = _mapper.Map<Departamento>(departamentoD);

        _unitOfWork.Departamentos.Add(dep);
        int num = await _unitOfWork.SaveChanges();

        return CreatedAtAction(nameof(Add),new {id = dep.DepartamentoID},dep);
    }


    [HttpPost("AddRangeDep")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult> AddRange(IEnumerable<DepartamentoDto> depDto)
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
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<DepartamentoDto>> GetById(int id)
    {
           Departamento dep = await _unitOfWork.Departamentos.GetById(id);
           
           return _mapper.Map<DepartamentoDto>(dep);
    }


    [HttpGet("GetAll")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]


    public async Task<IEnumerable<DepartamentoDto>> GetAll()
    {   
        IEnumerable<Departamento> deps = await _unitOfWork.Departamentos.GetAll();

        return _mapper.Map<IEnumerable<DepartamentoDto>>(deps);
    }

    [HttpGet("GetDepCities")]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<IEnumerable<DepartamentoCiudadDto>> GetAllDeps()
    {
        IEnumerable<Departamento> deps =await  _unitOfWork.Departamentos.GetAll();
        return _mapper.Map<IEnumerable<DepartamentoCiudadDto>>(deps);
      
    }


   [HttpDelete("{id}")]
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
   [ProducesResponseType(StatusCodes.Status200OK)]
   [ProducesResponseType(StatusCodes.Status400BadRequest)]

   public async Task<ActionResult<Departamento>> Update(int id,[FromBody]DepartamentoDto depDto)
   {
        Departamento dep = _mapper.Map<Departamento>(depDto);

        _unitOfWork.Departamentos.Update(dep);

        int num =await  _unitOfWork.SaveChanges();
        if (num == 0)
             return BadRequest();

        return dep ;
   }


}