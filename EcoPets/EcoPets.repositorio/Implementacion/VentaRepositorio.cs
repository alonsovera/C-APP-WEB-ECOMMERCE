using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EcoPets.model.Models;
using EcoPets.repositorio.Contrato;
using EcoPets.repositorio.DBContext.Data;

namespace EcoPets.repositorio.Implementacion
{
    public class VentaRepositorio : GenericoRepositorio<Venta>, IVentaRepositorio
    {
        private readonly EcopetsContext _dbContext;
        public VentaRepositorio(EcopetsContext dbContext) : base(dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task<Venta> Registrar(Venta modelo)
        {
            Venta ventaGenerada = new Venta();

            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    foreach (DetalleVenta dv in modelo.DetalleVenta)
                    {
                        Producto producto_encontrado = _dbContext.Productos.Where(p => p.IdProducto == dv.IdProducto).First();

                        producto_encontrado.Cantidad = producto_encontrado.Cantidad - dv.Cantidad;
                        _dbContext.Productos.Update(producto_encontrado);
                    }
                    await _dbContext.SaveChangesAsync();
                    await _dbContext.Venta.AddAsync(modelo);
                    await _dbContext.SaveChangesAsync();

                    ventaGenerada = modelo;
                    transaction.Commit();
                }
                catch
                {
                   transaction.Rollback();
                    throw;
                }
            }

            return ventaGenerada;
        }
    }
}
