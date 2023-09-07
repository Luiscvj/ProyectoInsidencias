 using API.DTOS;
using API.DTOS.ROLDTO;
using AutoMapper;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;


public class RolController : BaseApiController
{
    public RolController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }
    
    [HttpPost("AddRol")]
    [Authorize(Roles = "Gerente,Administrador")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult> Add(RolDto RolD)
    {
        Rol Rol = _mapper.Map<Rol>(RolD);
        _unitOfWork.Roles.Add(Rol);


        
        int num = await _unitOfWork.SaveChanges();

        return CreatedAtAction(nameof(Add),new {id = Rol.RolId},Rol);
    }


    [HttpPost("AddRangeRol")]
    [Authorize(Roles = "Gerente,Administrador")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult> AddRange(IEnumerable<RolDto> depDto)
    {
            if(depDto == null)
                return BadRequest();

            IEnumerable<Rol> Rols = _mapper.Map<IEnumerable<Rol>>(depDto);

            _unitOfWork.Roles.AddRange(Rols);
            int num = await _unitOfWork.SaveChanges();

            foreach(Rol d in Rols)
            {
                CreatedAtAction(nameof(AddRange), new {id = d.RolId},d);

            }

            return Ok();
    }

    [HttpGet("GetByID/{id}")]

    [Authorize(Roles = "Gerente,Administrador,Trainer,Empleado,Estudiante")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<RolDto>> GetById(int id)
    {
           Rol Rol = await _unitOfWork.Roles.GetById(id);
           
           return _mapper.Map<RolDto>(Rol);
    }


    [HttpGet("GetAll")]
    [MapToApiVersion("1.0")]
    [Authorize(Roles = "Gerente,Administrador")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]


    public async Task<IEnumerable<RolDto>> GetAll()
    {   
        IEnumerable<Rol> Rol = await _unitOfWork.Roles.GetAll();

        return _mapper.Map<IEnumerable<RolDto>>(Rol);
    } 

   /*  [HttpGet("GetElementoRol")]
    [MapToApiVersion("1.1")]
    [Authorize(Roles = "Gerente,Administrador")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<IEnumerable<RolDto>> GetAllElementos()
    {
        IEnumerable<Rol> Rol =await  _unitOfWork.Roles.GetAll();
        return _mapper.Map<IEnumerable<RolDto>>(Rol);
      
    } */


   [HttpDelete("{id}")]
   [Authorize(Roles = "Gerente,Administrador")]
   [ProducesResponseType(StatusCodes.Status200OK)]
   [ProducesResponseType(StatusCodes.Status400BadRequest)]

   public async Task<ActionResult> Delete(int id)
   {
        Rol Rol = await _unitOfWork.Roles.GetById(id);

        _unitOfWork.Roles.Remove(Rol);
        int num = await _unitOfWork.SaveChanges();

        if(num == 0)
            return BadRequest();
        
        return NoContent();
   }

   [HttpPut("UpdateRol")]
   [Authorize(Roles = "Gerente,Administrador,Trainer,Empleado,Estudiante")]
   [ProducesResponseType(StatusCodes.Status200OK)]
   [ProducesResponseType(StatusCodes.Status400BadRequest)]

   public async Task<ActionResult<Rol>> Update(int id,[FromBody]RolDto RolD)
   {
        Rol Rol = _mapper.Map<Rol>(RolD);

        _unitOfWork.Roles.Update(Rol);

        int num =await  _unitOfWork.SaveChanges();
        if (num == 0)
             return BadRequest();

        return Rol ;
   }


} 