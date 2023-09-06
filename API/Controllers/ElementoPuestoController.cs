using API.DTOS;
using AutoMapper;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;


public class ElementoPuestoController : BaseApiController
{
    public ElementoPuestoController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }

       
    [HttpPost("AddElementoP")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult> Add(ElementoPuestoDto elementoPD)
    {
        ElementoPuesto elementoP = _mapper.Map<ElementoPuesto>(elementoPD);

        _unitOfWork.ElementoPuestos.Add(elementoP);
        int num = await _unitOfWork.SaveChanges();

        return CreatedAtAction(nameof(Add),new {id = elementoP.Id},elementoP);
    }


    [HttpPost("AddRangeElementoP")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult> AddRange(IEnumerable<ElementoPuestoDto> elementoPD)
    {
            if(elementoPD == null)
                return BadRequest();

            IEnumerable<ElementoPuesto> elementoP = _mapper.Map<IEnumerable<ElementoPuesto>>(elementoPD);

            _unitOfWork.ElementoPuestos.AddRange(elementoP);
            int num = await _unitOfWork.SaveChanges();

            foreach(ElementoPuesto d in elementoP)
            {
                CreatedAtAction(nameof(AddRange), new {id = d.Id},d);

            }

            return Ok();
    }

    [HttpGet("GetByID/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<ElementoPuestoDto>> GetById(int id)
    {
           ElementoPuesto elementoP = await _unitOfWork.ElementoPuestos.GetById(id);
           
           return _mapper.Map<ElementoPuestoDto>(elementoP);
    }


    [HttpGet("GetAll")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]


    public async Task<IEnumerable<ElementoPuestoDto>> GetAll()
    {   
        IEnumerable<ElementoPuesto> elementoP = await _unitOfWork.ElementoPuestos.GetAll();

        return _mapper.Map<IEnumerable<ElementoPuestoDto>>(elementoP);
    }

    [HttpGet("GetElementoP")]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<IEnumerable<DepartamentoCiudadDto>> GetAllelementoP()
    {
        IEnumerable<ElementoPuesto> elementoP =await  _unitOfWork.ElementoPuestos.GetAll();
        return _mapper.Map<IEnumerable<DepartamentoCiudadDto>>(elementoP);
      
    }


   [HttpDelete("{id}")]
   [ProducesResponseType(StatusCodes.Status200OK)]
   [ProducesResponseType(StatusCodes.Status400BadRequest)]

   public async Task<ActionResult> Delete(int id)
   {
        ElementoPuesto elementoP = await _unitOfWork.ElementoPuestos.GetById(id);

        _unitOfWork.ElementoPuestos.Remove(elementoP);
        int num = await _unitOfWork.SaveChanges();

        if(num == 0)
            return BadRequest();
        
        return NoContent();
   }

   [HttpPut("UpdateElementoP")]
   [ProducesResponseType(StatusCodes.Status200OK)]
   [ProducesResponseType(StatusCodes.Status400BadRequest)]

   public async Task<ActionResult<ElementoPuesto>> Update(int id,[FromBody]ElementoPuestoDto elementoPD)
   {
        ElementoPuesto elementoP = _mapper.Map<ElementoPuesto>(elementoPD);

        _unitOfWork.ElementoPuestos.Update(elementoP);

        int num =await  _unitOfWork.SaveChanges();
        if (num == 0)
             return BadRequest();

        return elementoP ;
   }

}