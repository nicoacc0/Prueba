using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prueba.Model;

namespace Prueba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ProductoController(AppDbContext context)
        {
            _context = context;

        }

        //Leer
        [HttpGet]
        [Route("ObtenerProductos")]

        public async Task<IActionResult> ObtenerProductos()
        {
            var AllProductos = await _context.TblProductos.ToListAsync();
            return Ok(AllProductos);
        }

        [HttpPost]
        [Route("AgregarProducto")]
        public async Task<IActionResult> AgregarProducto(Producto P)
        {
            var existe = await _context.TblProductos.Where(x => x.Nombre == P.Nombre).FirstOrDefaultAsync();

            if (existe == null)
            {
                _context.Add(P);
                await _context.SaveChangesAsync();
                return Ok();

            }
            return BadRequest("Producto Existe");

        }

        [HttpPut]
        [Route("ActualizarProducto")]
        public async Task<IActionResult> ActualizarProducto(int ProductoId , Producto P)
        {
            var existe = _context.TblProductos.Where(x=> x.ProductoId == ProductoId).FirstOrDefault();
            if (existe == null)
            {
                return NotFound();
            }
                
            existe.Nombre = P.Nombre;
            existe.Descripcion = P.Descripcion;
            await _context.SaveChangesAsync();
            return Ok();

        }

        [HttpDelete]
        [Route("EliminarProducto")]
        public async Task<IActionResult> EliminarProducto(int ProductoId)
        {
            var existe = _context.TblProductos.Where(x => x.ProductoId == ProductoId).FirstOrDefault();
            if (existe == null)
            {
                return NotFound();
            }

            _context.Remove(existe);
            await _context.SaveChangesAsync();
            return Ok();

        }

        [HttpGet]
        [Route("ObtenerSegunId")]
        public async Task<IActionResult> ObtenerSegunId(int I)
        { 
            var Idpctos = await _context.TblProductos.FirstOrDefaultAsync(x => x.ProductoId == I);
            if (Idpctos == null)
            {
                return NotFound();
            }
            return Ok(Idpctos);
        }


    }
}