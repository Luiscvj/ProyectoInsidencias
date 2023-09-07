using API.DTOS;
using AutoMapper;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;


public class SesionUsoController : BaseApiController
{
    public SesionUsoController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }

      
    [HttpPost("AddSesionUsoDto")]
    [Authorize(Roles ="Gerente,Administrador")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult> Add(SesionUsoDto SesionUsoDtoD)
    {
        SesionUso sesionUso = _mapper.Map<SesionUso>(SesionUsoDtoD);

        _unitOfWork.SesionUsos.Add(sesionUso);
        int num = await _unitOfWork.SaveChanges();

        return CreatedAtAction(nameof(Add),new {id = sesionUso.PersonaId,sesionUso.PuestoID},sesionUso);
    }


    [HttpPost("AddRangeSes")]
    [Authorize(Roles ="Gerente,Administrador")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult> AddRange(IEnumerable<SesionUsoDto> SesDto)
    {
            if(SesDto == null)
                return BadRequest();

            IEnumerable<SesionUso> sesionesUso = _mapper.Map<IEnumerable<SesionUso>>(SesDto);

            _unitOfWork.SesionUsos.AddRange(sesionesUso);
            int num = await _unitOfWork.SaveChanges();

            foreach(SesionUso d in sesionesUso)
            {
                CreatedAtAction(nameof(AddRange), new {id = d.PersonaId,d.PuestoID},d);

            }

            return Ok();
    }

    [HttpGet("GetByID/{id}")]
    [Authorize(Roles ="Gerente,Administrador,Trainer,Estudiante,Empleado")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<SesionUsoDto>> GetById(int id)
    {
           SesionUso sesionUso = await _unitOfWork.SesionUsos.GetById(id);
           
           return _mapper.Map<SesionUsoDto>(sesionUso);
    }


    [HttpGet("GetAll")]
    [MapToApiVersion("1.0")]
    [Authorize(Roles ="Gerente,Administrador,Trainer,Estudiante,Empleado")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]


    public async Task<IEnumerable<SesionUsoDto>> GetAll()
    {   
        IEnumerable<SesionUso> sesionUso = await _unitOfWork.SesionUsos.GetAll();

        return _mapper.Map<IEnumerable<SesionUsoDto>>(sesionUso);
    }

    [HttpGet("GetSesionUsos")]
    [MapToApiVersion("1.1")]
    [Authorize(Roles ="Gerente,Administrador,Trainer,Estudiante,Empleado")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<IEnumerable<SesionUsoDto>> GetAllDSesionUsoDto()
    {
        IEnumerable<SesionUso> sesionUso =await  _unitOfWork.SesionUsos.GetAll();
        return _mapper.Map<IEnumerable<SesionUsoDto>>(sesionUso);
      
    }


   [HttpDelete("{id}")]
   [Authorize(Roles ="Gerente,Administrador")]
   [ProducesResponseType(StatusCodes.Status200OK)]
   [ProducesResponseType(StatusCodes.Status400BadRequest)]

   public async Task<ActionResult> Delete(int id)
   {
        SesionUso sesionUso = await _unitOfWork.SesionUsos.GetById(id);

        _unitOfWork.SesionUsos.Remove(sesionUso);
        int num = await _unitOfWork.SaveChanges();

        if(num == 0)
            return BadRequest();
        
        return NoContent();
   }

   [HttpPut("UpdateSes")]
   [Authorize(Roles ="Gerente,Administrador")]
   [ProducesResponseType(StatusCodes.Status200OK)]
   [ProducesResponseType(StatusCodes.Status400BadRequest)]

   public async Task<ActionResult<SesionUso>> Update(int id,[FromBody]SesionUsoDto SesDto)
   {
        SesionUso sesionUso = _mapper.Map<SesionUso>(SesDto);

        _unitOfWork.SesionUsos.Update(sesionUso);

        int num =await  _unitOfWork.SaveChanges();
        if (num == 0)
             return BadRequest();

        return sesionUso ;
   }
 

}