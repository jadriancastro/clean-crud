using CleanCrud.Application.Productos;
using CleanCrud.Domain.Entidades;
using CleanCrud.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CleanCrud.Presentation.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : ControllerBase
    {
        private readonly ProductoService _productoService;

        public ProductosController(ProductoService productoService)
        {
            _productoService = productoService;
        }

        // GET: api/productos
        [HttpGet]
        public async Task<IActionResult> ObtenerProductos()
        {
            var productos = await _productoService.ObtenerProductos();
            return Ok(productos);
        }

        // GET: api/productos/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerProductoPorId(Guid id)
        {
            var producto = await _productoService.ObtenerProductoPorId(id);
            if (producto == null)
                return NotFound();
            return Ok(producto);
        }

        // POST: api/productos
        [HttpPost]
        public async Task<IActionResult> CrearProducto([FromBody] Producto producto)
        {
            if (producto == null)
                return BadRequest();

            await _productoService.CrearProducto(producto);
            return CreatedAtAction(nameof(ObtenerProductoPorId), new { id = producto.Id }, producto);
        }

        // PUT: api/productos/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarProducto(Guid id, [FromBody] Producto producto)
        {
            if (producto == null || producto.Id != id)
                return BadRequest();

            var productoExistente = await _productoService.ObtenerProductoPorId(id);
            if (productoExistente == null)
                return NotFound();

            await _productoService.ActualizarProducto(producto);
            return NoContent();
        }

        // DELETE: api/productos/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarProducto(Guid id)
        {
            var productoExistente = await _productoService.ObtenerProductoPorId(id);
            if (productoExistente == null)
                return NotFound();

            await _productoService.EliminarProducto(id);
            return NoContent();
        }
    }
}
