using API.DTOS;
using AutoMapper;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;


public class PuestoController : BaseApiController
{
    public PuestoController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }

    [HttpPost("AddPuesto")]
    [Authorize(Roles = "Gerente,Administrador")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult> Add(Puesto_Dto PuestoD)
    {
        Puesto puesto = _mapper.Map<Puesto>(PuestoD);

        _unitOfWork.Puestos.Add(puesto);
        int num = await _unitOfWork.SaveChanges();

        return CreatedAtAction(nameof(Add),new {id = puesto.PuestoID},puesto);
    }


    [HttpPost("AddRangePuesto")]
    [Authorize(Roles = "Gerente,Administrador")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult> AddRange(IEnumerable<Puesto_Dto> puesto_Dto)
    {
            if(puesto_Dto == null)
                return BadRequest();

            IEnumerable<Puesto> puestos = _mapper.Map<IEnumerable<Puesto>>(puesto_Dto);

            _unitOfWork.Puestos.AddRange(puestos);
            int num = await _unitOfWork.SaveChanges();

            foreach(Puesto d in puestos)
            {
                CreatedAtAction(nameof(AddRange), new {id = d.PuestoID},d);

            }

            return Ok();
    }

    [HttpGet("GetByID/{id}")]
    [Authorize(Roles = "Gerente,Administrador,Trainer")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Puesto_Dto>> GetById(int id)
    {
           Puesto puesto = await _unitOfWork.Puestos.GetById(id);
           
           return _mapper.Map<Puesto_Dto>(puesto);
    }


    [HttpGet("GetAll")]
    [MapToApiVersion("1.0")]
    [Authorize(Roles = "Gerente,Administrador,Trainer")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]


    public async Task<IEnumerable<Puesto_Dto>> GetAll()
    {   
        IEnumerable<Puesto> puesto = await _unitOfWork.Puestos.GetAll();

        return _mapper.Map<IEnumerable<Puesto_Dto>>(puesto);
    }

    [HttpGet("GetDepCities")]
    [MapToApiVersion("1.1")]
    [Authorize(Roles = "Gerente,Administrador")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<IEnumerable<Puesto_Dto>> GetAllDPuesto()
    {
        IEnumerable<Puesto> puesto =await  _unitOfWork.Puestos.GetAll();
        return _mapper.Map<IEnumerable<Puesto_Dto>>(puesto);
      
    }


   [HttpDelete("{id}")]
   [Authorize(Roles = "Gerente,Administrador")]
   [ProducesResponseType(StatusCodes.Status200OK)]
   [ProducesResponseType(StatusCodes.Status400BadRequest)]

   public async Task<ActionResult> Delete(int id)
   {
        Puesto puesto = await _unitOfWork.Puestos.GetById(id);

        _unitOfWork.Puestos.Remove(puesto);
        int num = await _unitOfWork.SaveChanges();

        if(num == 0)
            return BadRequest();
        
        return NoContent();
   }

   [HttpPut("UpdatePuesto")]
   [Authorize(Roles = "Gerente,Administrador")]
   [ProducesResponseType(StatusCodes.Status200OK)]
   [ProducesResponseType(StatusCodes.Status400BadRequest)]

   public async Task<ActionResult<Puesto>> Update(int id,[FromBody]Puesto_Dto Puesto_Dto)
   {
        Puesto puesto = _mapper.Map<Puesto>(Puesto_Dto);

        _unitOfWork.Puestos.Update(puesto);

        int num =await  _unitOfWork.SaveChanges();
        if (num == 0)
             return BadRequest();

        return puesto ;
   }

}