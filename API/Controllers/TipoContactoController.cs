using API.DTOS;
using AutoMapper;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class TipoContactoController : BaseApiController
{
    public TipoContactoController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }

    [HttpPost("AddCategoria")]
    [Authorize(Roles ="Gerente,Administrador")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult> Add(TipoContactoDto tipoContactoD)
    {
        TipoContacto tipoContacto = _mapper.Map<TipoContacto>(tipoContactoD);
        _unitOfWork.TiposContacto.Add(tipoContacto);


        
        int num = await _unitOfWork.SaveChanges();

        return CreatedAtAction(nameof(Add),new {id = tipoContacto.TipoContactoID},tipoContacto);
    }


    [HttpPost("AddRangeDep")]
    [Authorize(Roles ="Gerente,Administrador")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult> AddRange(IEnumerable<TipoContactoDto> depDto)
    {
            if(depDto == null)
                return BadRequest();

            IEnumerable<TipoContacto> TiposContacto = _mapper.Map<IEnumerable<TipoContacto>>(depDto);

            _unitOfWork.TiposContacto.AddRange(TiposContacto);
            int num = await _unitOfWork.SaveChanges();

            foreach(TipoContacto d in TiposContacto)
            {
                CreatedAtAction(nameof(AddRange), new {id = d.TipoContactoID},d);

            }

            return Ok();
    }

    [HttpGet("GetByID/{id}")]
    [Authorize(Roles ="Gerente,Administrador")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<TipoContactoDto>> GetById(int id)
    {
           TipoContacto categoria = await _unitOfWork.TiposContacto.GetById(id);
           
           return _mapper.Map<TipoContactoDto>(categoria);
    }


    [HttpGet("GetAll")]
    [MapToApiVersion("1.0")]
    [Authorize(Roles ="Gerente,Administrador")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]


    public async Task<IEnumerable<TipoContactoDto>> GetAll()
    {   
        IEnumerable<TipoContacto> cities = await _unitOfWork.TiposContacto.GetAll();

        return _mapper.Map<IEnumerable<TipoContactoDto>>(cities);
    }

   /*  [HttpGet("GetcategoriaCities")]
    [MapToApiVersion("1.1")]
    [Authorize(Roles ="Gerente,Administrador")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<IEnumerable<TipoContactoDto>> GetAllTiposContacto()
    {
        IEnumerable<TipoContacto> cities =await  _unitOfWork.TiposContacto.GetAll();
        return _mapper.Map<IEnumerable<TipoContactoDto>>(cities);
      
    } */


   [HttpDelete("{id}")]
   [Authorize(Roles ="Gerente,Administrador")]
   [ProducesResponseType(StatusCodes.Status200OK)]
   [ProducesResponseType(StatusCodes.Status400BadRequest)]

   public async Task<ActionResult> Delete(int id)
   {
        TipoContacto categoria = await _unitOfWork.TiposContacto.GetById(id);

        _unitOfWork.TiposContacto.Remove(categoria);
        int num = await _unitOfWork.SaveChanges();

        if(num == 0)
            return BadRequest();
        
        return NoContent();
   }

   [HttpPut("Updatecategoria")]
   [Authorize(Roles ="Gerente,Administrador")]
   [ProducesResponseType(StatusCodes.Status200OK)]
   [ProducesResponseType(StatusCodes.Status400BadRequest)]

   public async Task<ActionResult<TipoContacto>> Update(int id,[FromBody]TipoContactoDto TipoContactoDto)
   {
        TipoContacto tipoContacto = _mapper.Map<TipoContacto>(TipoContactoDto);

        _unitOfWork.TiposContacto.Update(tipoContacto);

        int num =await  _unitOfWork.SaveChanges();
        if (num == 0)
             return BadRequest();

        return tipoContacto ;
   }


}