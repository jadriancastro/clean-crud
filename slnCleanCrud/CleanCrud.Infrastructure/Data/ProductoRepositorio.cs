using CleanCrud.Domain.Entidades;
using CleanCrud.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCrud.Infrastructure.Data
{
    public class ProductoRepositorio : IProductoRepositorio
    {
        private readonly List<Producto> _productos = new List<Producto>()
        {
    new Producto
    {
        Id = Guid.NewGuid(),
        Nombre = "Laptop Dell XPS 13",
        Precio = 1200.50m
    },
    new Producto
    {
        Id = Guid.NewGuid(),
        Nombre = "Smartphone Samsung Galaxy S23",
        Precio = 950.00m
    },
    new Producto
    {
        Id = Guid.NewGuid(),
        Nombre = "Teclado Mecánico Logitech",
        Precio = 150.75m
    },
    new Producto
    {
        Id = Guid.NewGuid(),
        Nombre = "Monitor LG UltraWide 34\"",
        Precio = 499.99m
    },
    new Producto
    {
        Id = Guid.NewGuid(),
        Nombre = "Silla Gamer Corsair",
        Precio = 299.90m
    }
};

        public Task ActualizarAsync(Producto producto)
        {
            var productoExistente = _productos.FirstOrDefault(p => p.Id == producto.Id);
            if (productoExistente != null)
            {
                productoExistente.Nombre = producto.Nombre;
                productoExistente.Precio = producto.Precio;
            }
            return Task.CompletedTask;
        }

        public Task CrearAsync(Producto producto)
        {
            _productos.Add(producto);
            return Task.CompletedTask;
        }

        public Task EliminarAsync(Guid id)
        {
            var producto = _productos.FirstOrDefault(p => p.Id == id);
            if (producto != null)
            {
                _productos.Remove(producto);
            }
            return Task.CompletedTask;
        }

        public Task<Producto> ObtenerPorIdAsync(Guid id)
        {
            var producto = _productos.FirstOrDefault(p => p.Id == id);
            return Task.FromResult(producto);
        }

        public Task<IEnumerable<Producto>> ObtenerTodosAsync()
        {
            return Task.FromResult<IEnumerable<Producto>>(_productos);
        }
    }
}
