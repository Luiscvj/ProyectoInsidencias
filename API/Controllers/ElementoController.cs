using API.DTOS;
using AutoMapper;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class ElementoController : BaseApiController
{
    public ElementoController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }

    
    [HttpPost("AddElemento")]
    [Authorize(Roles = "Gerente,Administrador")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult> Add(ElementoDto ElementoD)
    {
        Elemento elemento = _mapper.Map<Elemento>(ElementoD);
        _unitOfWork.Elementos.Add(elemento);


        
        int num = await _unitOfWork.SaveChanges();

        return CreatedAtAction(nameof(Add),new {id = elemento.ElementoID},elemento);
    }


    [HttpPost("AddRangeElemento")]
    [Authorize(Roles = "Gerente,Administrador")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult> AddRange(IEnumerable<ElementoDto> depDto)
    {
            if(depDto == null)
                return BadRequest();

            IEnumerable<Elemento> Elementos = _mapper.Map<IEnumerable<Elemento>>(depDto);

            _unitOfWork.Elementos.AddRange(Elementos);
            int num = await _unitOfWork.SaveChanges();

            foreach(Elemento d in Elementos)
            {
                CreatedAtAction(nameof(AddRange), new {id = d.ElementoID},d);

            }

            return Ok();
    }

    [HttpGet("GetByID/{id}")]
    [Authorize(Roles = "Gerente,Administrador,Trainer")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<ElementoDto>> GetById(int id)
    {
           Elemento Elemento = await _unitOfWork.Elementos.GetById(id);
           
           return _mapper.Map<ElementoDto>(Elemento);
    }


    [HttpGet("GetAll")]
    [MapToApiVersion("1.0")]
    [Authorize(Roles = "Gerente,Administrador,Trainer")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]


    public async Task<IEnumerable<ElementoDto>> GetAll()
    {   
        IEnumerable<Elemento> elemento = await _unitOfWork.Elementos.GetAll();

        return _mapper.Map<IEnumerable<ElementoDto>>(elemento);
    }

   /*  [HttpGet("GetElementoelemento")]
    [MapToApiVersion("1.1")]
    [Authorize(Roles = "Gerente,Administrador")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<IEnumerable<ElementoDto>> GetAllElementos()
    {
        IEnumerable<Elemento> elemento =await  _unitOfWork.Elementos.GetAll();
        return _mapper.Map<IEnumerable<ElementoDto>>(elemento);
      
    } */


   [HttpDelete("{id}")]
   [Authorize(Roles = "Gerente,Administrador")]
   [ProducesResponseType(StatusCodes.Status200OK)]
   [ProducesResponseType(StatusCodes.Status400BadRequest)]

   public async Task<ActionResult> Delete(int id)
   {
        Elemento Elemento = await _unitOfWork.Elementos.GetById(id);

        _unitOfWork.Elementos.Remove(Elemento);
        int num = await _unitOfWork.SaveChanges();

        if(num == 0)
            return BadRequest();
        
        return NoContent();
   }

   [HttpPut("UpdateElemento")]
   [Authorize(Roles = "Gerente,Administrador")]
   [ProducesResponseType(StatusCodes.Status200OK)]
   [ProducesResponseType(StatusCodes.Status400BadRequest)]

   public async Task<ActionResult<Elemento>> Update(int id,[FromBody]ElementoDto ElementoDto)
   {
        Elemento Elemento = _mapper.Map<Elemento>(ElementoDto);

        _unitOfWork.Elementos.Update(Elemento);

        int num =await  _unitOfWork.SaveChanges();
        if (num == 0)
             return BadRequest();

        return Elemento ;
   }
}