using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prueba.Model;

namespace Prueba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly AppDbContext _context;
        public CategoriaController(AppDbContext context)
        {
            _context = context;

        }

        [HttpGet]
        [Route("ObtenerCategoria")]

        public async Task<IActionResult> ObtenerCategoria()
        {
            var AllCategoria = await _context.TblCategorias.ToListAsync();
            return Ok(AllCategoria);
        }

        [HttpPost]
        [Route("AgregarCategoria")]

        public async Task<IActionResult> AgregarCategoria(CategoriaDTO C)
        {

            var ncategoria = new Categoria()
            {
                CategoriaId = C.CategoriaId,
                Nombre = C.Nombre,
                Descripcion = C.Descripcion,
            };
            var existe = await _context.TblCategorias.Where(x => x.Nombre == C.Nombre).FirstOrDefaultAsync();

            if (existe == null)
            {
                _context.Add(ncategoria);
                await _context.SaveChangesAsync();
                return Ok();

            }
            return BadRequest("Producto Existe");

        }

        [HttpPut]
        [Route("ActualizarCategoria")]
        public async Task<IActionResult> ActualizarCategoria(int CategoriaId, CategoriaDTO C)
        {
            var ncategoria = new Categoria()
            {
                CategoriaId = C.CategoriaId,
                Nombre = C.Nombre,
                Descripcion = C.Descripcion,
            };

            var existe = _context.TblCategorias.Where(x => x.CategoriaId == CategoriaId).FirstOrDefault();
            if (existe == null)
            {
                return NotFound();
            }

            existe.Nombre = C.Nombre;
            existe.Descripcion = C.Descripcion;
            await _context.SaveChangesAsync();
            return Ok();

        }

        [HttpDelete]
        [Route("EliminarCategoria")]
        public async Task<IActionResult> EliminarProducto(int CategoriaId)
        {
            var existe = _context.TblCategorias.Where(x => x.CategoriaId == CategoriaId).FirstOrDefault();
            if (existe == null)
            {
                return NotFound();
            }
            _context.Remove(existe);
            await _context.SaveChangesAsync();
            return Ok();

        }


        [HttpGet]
        [Route("ObtenerCategoriaSegunId")]
        public async Task<IActionResult> ObtenerCategoriaSegunId(int I)
        {
            var IdCateg = await _context.TblCategorias.FirstOrDefaultAsync(x => x.CategoriaId == I);
            if (IdCateg == null)
            {
                return NotFound();
            }
            return Ok(IdCateg);
        }

        [HttpGet]
        [Route("ObtenerCategoriaSegunNombre")]
        public async Task<IActionResult> ObtenerCategoriaSegunNombre(string N)
        {
            var NCateg = await _context.TblCategorias.Where(x => x.Nombre == N).FirstOrDefaultAsync();
            if (NCateg == null)
            {
                return NotFound();
            }
            return Ok(NCateg);
        }

    }

    
}
