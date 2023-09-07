using API.DTOS;
using AutoMapper;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class ContactoArlController : BaseApiController
{
    public ContactoArlController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }

    [HttpPost("AddContactoArl")]
    [Authorize(Roles ="Administrador,Gerente")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult> Add(ContactoArlDto ContactoD)
    {
        ContactoArl d = _mapper.Map<ContactoArl>(ContactoD);
        _unitOfWork.ContactosArl.Add(d);


        
        int num = await _unitOfWork.SaveChanges();

        return CreatedAtAction(nameof(Add),new {id = d.ArlId,d.TipoContactoId },d);
    }


    [HttpPost("AddRangeContactoArl")]
    [Authorize(Roles ="Administrador,Gerente")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult> AddRange(IEnumerable<ContactoArlDto> depDto)
    {
            if(depDto == null)
                return BadRequest();

            IEnumerable<ContactoArl> contactosArl = _mapper.Map<IEnumerable<ContactoArl>>(depDto);

            _unitOfWork.ContactosArl.AddRange(contactosArl);
            int num = await _unitOfWork.SaveChanges();

            foreach(ContactoArl d in contactosArl)
            {
                CreatedAtAction(nameof(AddRange), new {id = d.ArlId,d.TipoContactoId },d);

            }

            return Ok();
    }

    [HttpGet("GetByID/{id}")]
    [Authorize(Roles ="Administrador,Gerente,Trainer,Empleado")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<ContactoArlDto>> GetById(int id)
    {
           ContactoArl ContactoArl = await _unitOfWork.ContactosArl.GetById(id);
           
           return _mapper.Map<ContactoArlDto>(ContactoArl);
    }


    [HttpGet("GetAll")]
    [MapToApiVersion("1.0")]
    [Authorize(Roles ="Administrador,Gerente,Trainer,Empleado")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]


    public async Task<IEnumerable<ContactoArlDto>> GetAll()
    {   
        IEnumerable<ContactoArl> cities = await _unitOfWork.ContactosArl.GetAll();

        return _mapper.Map<IEnumerable<ContactoArlDto>>(cities);
    }

   /*  [HttpGet("GetContactoArlCities")]
    [MapToApiVersion("1.1")]
    [Authorize(Roles ="Administrador,Gerente")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<IEnumerable<ContactoArlDto>> GetAllContactosArl()
    {
        IEnumerable<ContactoArl> cities =await  _unitOfWork.ContactosArl.GetAll();
        return _mapper.Map<IEnumerable<ContactoArlDto>>(cities);
      
    } */


   [HttpDelete("{id}")]
   [Authorize(Roles ="Administrador,Gerente")]
   [ProducesResponseType(StatusCodes.Status200OK)]
   [ProducesResponseType(StatusCodes.Status400BadRequest)]

   public async Task<ActionResult> Delete(int id)
   {
        ContactoArl contactoArl = await _unitOfWork.ContactosArl.GetById(id);

        _unitOfWork.ContactosArl.Remove(contactoArl);
        int num = await _unitOfWork.SaveChanges();

        if(num == 0)
            return BadRequest();
        
        return NoContent();
   }

   [HttpPut("UpdateContactoArl")]
   [Authorize(Roles ="Administrador,Gerente")]
   [ProducesResponseType(StatusCodes.Status200OK)]
   [ProducesResponseType(StatusCodes.Status400BadRequest)]

   public async Task<ActionResult<ContactoArl>> Update(int id,[FromBody]ContactoArlDto ContactoArlDto)
   {
        ContactoArl contactoArl = _mapper.Map<ContactoArl>(ContactoArlDto);

        _unitOfWork.ContactosArl.Update(contactoArl);

        int num =await  _unitOfWork.SaveChanges();
        if (num == 0)
             return BadRequest();

        return contactoArl ;
   }


}