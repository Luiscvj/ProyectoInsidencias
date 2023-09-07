using AutoMapper;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;


public class ContactoEpsController : BaseApiController
{
    public ContactoEpsController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }

    
   
    [HttpPost("AddContactoEps")]
    [Authorize (Roles ="Gerente,Administrador")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult> Add(ContactoEpsDto contactoEpsD)
    {
        ContactoEps contactoE = _mapper.Map<ContactoEps>(contactoEpsD);

        _unitOfWork.ContactosEps.Add(contactoE);
        int num = await _unitOfWork.SaveChanges();

        return CreatedAtAction(nameof(Add),new {id = contactoE.EpsId,contactoE.TipoContactoId},contactoE);
    }


    [HttpPost("AddRangecontactoE")]
    [Authorize (Roles ="Gerente,Administrador")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult> AddRange(IEnumerable<ContactoEpsDto> contactoEDto)
    {
            if(contactoEDto == null)
                return BadRequest();

            IEnumerable<ContactoEps> contactoEs = _mapper.Map<IEnumerable<ContactoEps>>(contactoEDto);

            _unitOfWork.ContactosEps.AddRange(contactoEs);
            int num = await _unitOfWork.SaveChanges();

            foreach(ContactoEps contactoE in contactoEs)
            {
                CreatedAtAction(nameof(AddRange), new {id = contactoE.EpsId,contactoE.TipoContactoId},contactoE);

            }

            return Ok();
    }

    [HttpGet("GetByID/{id}")]
    [Authorize (Roles ="Gerente,Administrador,Empleado,Trainer")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<ContactoEpsDto>> GetById(int id)
    {
           ContactoEps contactoE = await _unitOfWork.ContactosEps.GetById(id);
           
           return _mapper.Map<ContactoEpsDto>(contactoE);
    }


    [HttpGet("GetAll")]
    [MapToApiVersion("1.0")]
    [Authorize (Roles ="Gerente,Administrador,Empleado,Trainer")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]


    public async Task<IEnumerable<ContactoEpsDto>> GetAll()
    {   
        IEnumerable<ContactoEps> contactoEs = await _unitOfWork.ContactosEps.GetAll();

        return _mapper.Map<IEnumerable<ContactoEpsDto>>(contactoEs);
    }

    [HttpGet("GetcontactoE")]
    [MapToApiVersion("1.1")]
    [Authorize (Roles ="Gerente,Administrador")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<IEnumerable<ContactoEpsDto >> GetAllcontactoEs()
    {
        IEnumerable<ContactoEps> contactoEs =await  _unitOfWork.ContactosEps.GetAll();
        return _mapper.Map<IEnumerable<ContactoEpsDto>>(contactoEs);
      
    }


   [HttpDelete("{id}")]
   [Authorize (Roles ="Gerente,Administrador")]
   [ProducesResponseType(StatusCodes.Status200OK)]
   [ProducesResponseType(StatusCodes.Status400BadRequest)]

   public async Task<ActionResult> Delete(int id)
   {
        ContactoEps contactoE = await _unitOfWork.ContactosEps.GetById(id);

        _unitOfWork.ContactosEps.Remove(contactoE);
        int num = await _unitOfWork.SaveChanges();

        if(num == 0)
            return BadRequest();
        
        return NoContent();
   }

   [HttpPut("UpdatecontactoE")]
   [Authorize (Roles ="Gerente,Administrador")]
   [ProducesResponseType(StatusCodes.Status200OK)]
   [ProducesResponseType(StatusCodes.Status400BadRequest)]

   public async Task<ActionResult<ContactoEps>> Update(int id,[FromBody]ContactoEpsDto contactoEDto)
   {
        ContactoEps contactoE = _mapper.Map<ContactoEps>(contactoEDto);

        _unitOfWork.ContactosEps.Update(contactoE);

        int num =await  _unitOfWork.SaveChanges();
        if (num == 0)
             return BadRequest();

        return contactoE ;
   }


}