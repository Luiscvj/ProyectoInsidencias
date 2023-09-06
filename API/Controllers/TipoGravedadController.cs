using API.DTOS;
using AutoMapper;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;


public class TipoGravedadController : BaseApiController
{
    public TipoGravedadController(IUnitOfWork _unitOfWork, IMapper _mapper) : base(_unitOfWork,_mapper)
    {

    }

     
    [HttpPost("AddTipoGravedad")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult> Add(TipoGravedadDto tipoGD)
    {
        Tipo_Gravedad tipoG = _mapper.Map<Tipo_Gravedad>(tipoGD);
        _unitOfWork.Tipos_Gravedad.Add(tipoG);


        
        int num = await _unitOfWork.SaveChanges();

        return CreatedAtAction(nameof(Add),new {id = tipoG.Tipo_GravedadID},tipoG);
    }


    [HttpPost("AddRangeTipoG")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult> AddRange(IEnumerable<TipoGravedadDto> depDto)
    {
            if(depDto == null)
                return BadRequest();

            IEnumerable<Tipo_Gravedad> tipoGs = _mapper.Map<IEnumerable<Tipo_Gravedad>>(depDto);

            _unitOfWork.Tipos_Gravedad.AddRange(tipoGs);
            int num = await _unitOfWork.SaveChanges();

            foreach(Tipo_Gravedad d in tipoGs)
            {
                CreatedAtAction(nameof(AddRange), new {id = d.Tipo_GravedadID},d);

            }

            return Ok();
    }

    [HttpGet("GetByID/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<TipoGravedadDto>> GetById(int id)
    {
           Tipo_Gravedad tipoG = await _unitOfWork.Tipos_Gravedad.GetById(id);
           
           return _mapper.Map<TipoGravedadDto>(tipoG);
    }


    [HttpGet("GetAll")]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]


    public async Task<IEnumerable<TipoGravedadDto>> GetAll()
    {   
        IEnumerable<Tipo_Gravedad> tipoG = await _unitOfWork.Tipos_Gravedad.GetAll();

        return _mapper.Map<IEnumerable<TipoGravedadDto>>(tipoG);
    }

   /*  [HttpGet("tipoGS")]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<IEnumerable<TipoGravedadDto>> GetAlltipoGs()
    {
        IEnumerable<Tipo_Gravedad> tipoGS =await  _unitOfWork.Tipos_Gravedad.GetAll();
        return _mapper.Map<IEnumerable<TipoGravedadDto>>(tipoGS);
      
    } */


   [HttpDelete("{id}")]
   [ProducesResponseType(StatusCodes.Status200OK)]
   [ProducesResponseType(StatusCodes.Status400BadRequest)]

   public async Task<ActionResult> Delete(int id)
   {
        Tipo_Gravedad tipoG = await _unitOfWork.Tipos_Gravedad.GetById(id);

        _unitOfWork.Tipos_Gravedad.Remove(tipoG);
        int num = await _unitOfWork.SaveChanges();

        if(num == 0)
            return BadRequest();
        
        return NoContent();
   }

   [HttpPut("UpdateTipoGravedad")]
   [ProducesResponseType(StatusCodes.Status200OK)]
   [ProducesResponseType(StatusCodes.Status400BadRequest)]

   public async Task<ActionResult<Tipo_Gravedad>> Update(int id,[FromBody]TipoGravedadDto tipoGravedadDto)
   {
        Tipo_Gravedad tipoG = _mapper.Map<Tipo_Gravedad>(tipoGravedadDto);

        _unitOfWork.Tipos_Gravedad.Update(tipoG);

        int num =await  _unitOfWork.SaveChanges();
        if (num == 0)
             return BadRequest();

        return tipoG ;
   }




}