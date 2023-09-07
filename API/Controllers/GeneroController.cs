using API.DTOS;
using AutoMapper;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;


public class GeneroController : BaseApiController
{
    public GeneroController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }

     
    [HttpPost("AddGenero")]
    [Authorize(Roles = "Gerente,Administrador")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult> Add(GeneroDto GeneroD)
    {
        Genero e = _mapper.Map<Genero>(GeneroD);

        _unitOfWork.Generos.Add(e);
        int num = await _unitOfWork.SaveChanges();

        return CreatedAtAction(nameof(Add),new {id = e.GeneroID},e);
    }


    [HttpPost("AddRangeGenero")]
    [Authorize(Roles = "Gerente,Administrador")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult> AddRange(IEnumerable<GeneroDto> depDto)
    {
            if(depDto == null)
                return BadRequest();

            IEnumerable<Genero> e = _mapper.Map<IEnumerable<Genero>>(depDto);

            _unitOfWork.Generos.AddRange(e);
            int num = await _unitOfWork.SaveChanges();

            foreach(Genero d in e)
            {
                CreatedAtAction(nameof(AddRange), new {id = d.GeneroID},d);

            }

            return Ok();
    }

    [HttpGet("GetByID/{id}")]
    [Authorize(Roles = "Gerente,Administrador,Trainer,Empleado,Estudiante")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<GeneroDto>> GetById(int id)
    {
           Genero e = await _unitOfWork.Generos.GetById(id);
           
           return _mapper.Map<GeneroDto>(e);
    }


    [HttpGet("GetAll")]
    [MapToApiVersion("1.0")]
    [Authorize(Roles = "Gerente,Administrador,Trainer,Empleado,Estudiante")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]


    public async Task<IEnumerable<GeneroDto>> GetAll()
    {   
        IEnumerable<Genero> e = await _unitOfWork.Generos.GetAll();

        return _mapper.Map<IEnumerable<GeneroDto>>(e);
    }

    [HttpGet("GetGenero")]
    [MapToApiVersion("1.1")]
    [Authorize(Roles = "Gerente,Administrador,Trainer,Empleado,Estudiante")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<IEnumerable<GeneroDto>> GetAllDGenero()
    {
        IEnumerable<Genero> e =await  _unitOfWork.Generos.GetAll();
        return _mapper.Map<IEnumerable<GeneroDto>>(e);
      
    }


   [HttpDelete("{id}")]
   [Authorize(Roles = "Gerente,Administrador")]
   [ProducesResponseType(StatusCodes.Status200OK)]
   [ProducesResponseType(StatusCodes.Status400BadRequest)]

   public async Task<ActionResult> Delete(int id)
   {
        Genero e = await _unitOfWork.Generos.GetById(id);

        _unitOfWork.Generos.Remove(e);
        int num = await _unitOfWork.SaveChanges();

        if(num == 0)
            return BadRequest();
        
        return NoContent();
   }

   [HttpPut("UpdateGenero")]
   [Authorize(Roles = "Gerente,Administrador,Trainer,Empleado,Estudiante")]
   [ProducesResponseType(StatusCodes.Status200OK)]
   [ProducesResponseType(StatusCodes.Status400BadRequest)]

   public async Task<ActionResult<Genero>> Update(int id,[FromBody]GeneroDto depDto)
   {
        Genero e = _mapper.Map<Genero>(depDto);

        _unitOfWork.Generos.Update(e);

        int num =await  _unitOfWork.SaveChanges();
        if (num == 0)
             return BadRequest();

        return e ;
   }

}