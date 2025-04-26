using CleanCrud.Domain.Entidades;
using CleanCrud.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCrud.Application.Productos
{
    public class ProductoService
    {
        private readonly IProductoRepositorio _productoRepositorio;

        public ProductoService(IProductoRepositorio productoRepositorio)
        {
            _productoRepositorio = productoRepositorio;
        }

        public async Task<IEnumerable<Producto>> ObtenerProductos()
        {
            return await _productoRepositorio.ObtenerTodosAsync();
        }

        public async Task<Producto> ObtenerProductoPorId(Guid id)
        {
            return await _productoRepositorio.ObtenerPorIdAsync(id);
        }

        public async Task CrearProducto(Producto producto)
        {
            await _productoRepositorio.CrearAsync(producto);
        }

        public async Task ActualizarProducto(Producto producto)
        {
            await _productoRepositorio.ActualizarAsync(producto);
        }

        public async Task EliminarProducto(Guid id)
        {
            await _productoRepositorio.EliminarAsync(id);
        }
    }
}
