using API.DTOS;
using AutoMapper;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class CategoriaController : BaseApiController
{
    public CategoriaController(IUnitOfWork _unitOfWork, IMapper _mapper) : base(_unitOfWork, _mapper)
    {
    }
    
    [HttpPost("AddCategoria")]
    [Authorize(Roles = "Administrador,Gerente,Trainer")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult> Add(CategoriaDto CategoriaD)
    {
        Categoria cat = _mapper.Map<Categoria>(CategoriaD);
        _unitOfWork.Categorias.Add(cat);


        
        int num = await _unitOfWork.SaveChanges();

        return CreatedAtAction(nameof(Add),new {id = cat.CategoriaID},cat);
    }


    [HttpPost("AddRangeDep")]
    [Authorize(Roles = "Administrador,Gerente,Trainer")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult> AddRange(IEnumerable<CategoriaDto> depDto)
    {
            if(depDto == null)
                return BadRequest();

            IEnumerable<Categoria> categorias = _mapper.Map<IEnumerable<Categoria>>(depDto);

            _unitOfWork.Categorias.AddRange(categorias);
            int num = await _unitOfWork.SaveChanges();

            foreach(Categoria d in categorias)
            {
                CreatedAtAction(nameof(AddRange), new {id = d.CategoriaID},d);

            }

            return Ok();
    }

    [HttpGet("GetByID/{id}")]
    [Authorize(Roles = "Estudiante,Administrador,Gerente,Trainer")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<CategoriaDto>> GetById(int id)
    {
           Categoria categoria = await _unitOfWork.Categorias.GetById(id);
           
           return _mapper.Map<CategoriaDto>(categoria);
    }


    [HttpGet("GetAll")]
    [MapToApiVersion("1.0")]
    [Authorize(Roles = "Estudiante,Administrador,Gerente,Trainer")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]


    public async Task<IEnumerable<CategoriaDto>> GetAll()
    {   
        IEnumerable<Categoria> cities = await _unitOfWork.Categorias.GetAll();

        return _mapper.Map<IEnumerable<CategoriaDto>>(cities);
    }

   /*  [HttpGet("GetcategoriaCities")]
    [MapToApiVersion("1.1")]
    [Authorize(Roles = "Estudiante,Administrador,Gerente,Trainer")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<IEnumerable<CategoriaDto>> GetAllCategorias()
    {
        IEnumerable<Categoria> cities =await  _unitOfWork.Categorias.GetAll();
        return _mapper.Map<IEnumerable<CategoriaDto>>(cities);
      
    } */


   [HttpDelete("{id}")]
   [Authorize(Roles = "Administrador,Gerente,Trainer")]
   [ProducesResponseType(StatusCodes.Status200OK)]
   [ProducesResponseType(StatusCodes.Status400BadRequest)]

   public async Task<ActionResult> Delete(int id)
   {
        Categoria categoria = await _unitOfWork.Categorias.GetById(id);

        _unitOfWork.Categorias.Remove(categoria);
        int num = await _unitOfWork.SaveChanges();

        if(num == 0)
            return BadRequest();
        
        return NoContent();
   }

   [HttpPut("Updatecategoria")]
   [Authorize(Roles = "Administrador,Gerente,Trainer")]
   [ProducesResponseType(StatusCodes.Status200OK)]
   [ProducesResponseType(StatusCodes.Status400BadRequest)]

   public async Task<ActionResult<Categoria>> Update(int id,[FromBody]CategoriaDto categoriaDto)
   {
        Categoria categoria = _mapper.Map<Categoria>(categoriaDto);

        _unitOfWork.Categorias.Update(categoria);

        int num =await  _unitOfWork.SaveChanges();
        if (num == 0)
             return BadRequest();

        return categoria ;
   }


}