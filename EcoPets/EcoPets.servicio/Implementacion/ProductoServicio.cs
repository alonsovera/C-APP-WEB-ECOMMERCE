using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using EcoPets.model.Models;
using EcoPets.DTO;
using EcoPets.repositorio.Contrato;
using EcoPets.servicio.Contrato;
using AutoMapper;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace EcoPets.servicio.Implementacion
{
    public class ProductoServicio : IProductoServicio
    {
        private readonly IGenericoRepositorio<Producto> _modeloRepositorio;
        private readonly IMapper _mapper;
        public ProductoServicio(IGenericoRepositorio<Producto> modeloRepositorio, IMapper mapper)
        {
            _modeloRepositorio = modeloRepositorio;
            _mapper = mapper;
        }

        public async Task<List<ProductoDTO>> Catalogo(string categoria, string buscar)
        {
            try
            {
                var consulta = _modeloRepositorio.Consultar(p =>
                p.Nombre.ToLower().Contains(buscar.ToLower())  && p.IdCategoriaNavigation.Nombre.ToLower().Contains(categoria.ToLower())
                );

                List<ProductoDTO> lista = _mapper.Map<List<ProductoDTO>>(await consulta.ToListAsync());
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ProductoDTO> Crear(ProductoDTO modelo)
        {
            try
            {
                var dbModelo = _mapper.Map<Producto>(modelo);
                var rspModelo = await _modeloRepositorio.Crear(dbModelo);

                if (rspModelo.IdProducto != Guid.Empty)
                {
                    return _mapper.Map<ProductoDTO>(rspModelo);
                }
                else
                {
                    throw new TaskCanceledException("No se pudo crear");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Editar(ProductoDTO modelo)
        {
            try
            {
                var consulta = _modeloRepositorio.Consultar(p => p.IdProducto == modelo.IdProducto);
                var fromDbModelo = await consulta.FirstOrDefaultAsync();

                if (fromDbModelo != null)
                {
                    fromDbModelo.Nombre = modelo.Nombre;
                    fromDbModelo.PrecioOferta = modelo.PrecioOferta;
                    fromDbModelo.Precio = modelo.Precio;
                    fromDbModelo.Cantidad = modelo.Cantidad;
                    fromDbModelo.IdCategoria = modelo.IdCategoria;
                    fromDbModelo.Descripcion = modelo.Descripcion;
                    fromDbModelo.Imagen = modelo.Imagen;

                    var respuesta = await _modeloRepositorio.Editar(fromDbModelo);

                    if (!respuesta)
                    {
                        throw new TaskCanceledException("No se pudo editar");
                    }
                    return respuesta;
                }
                else
                {
                    throw new TaskCanceledException("No se encontraron resultados");

                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Eliminar(Guid id)
        {
            try
            {
                var consulta = _modeloRepositorio.Consultar(p => p.IdProducto == id);
                var fromDbModelo = await consulta.FirstOrDefaultAsync();

                if (fromDbModelo != null)
                {
                    var respuesta = await _modeloRepositorio.Eliminar(fromDbModelo);
                    if (!respuesta)
                    {
                        throw new TaskCanceledException("No se pudo eliminar");

                    }
                    return respuesta;
                }
                else
                {
                    throw new TaskCanceledException("No se encontraron resultados");

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<ProductoDTO>> Lista(string buscar)
        {
            try
            {
                var consulta = _modeloRepositorio.Consultar(p => 
                p.Nombre.ToLower().Contains(buscar.ToLower())
                );

                consulta = consulta.Include(c => c.IdCategoriaNavigation);

                List<ProductoDTO> lista = _mapper.Map<List<ProductoDTO>>(await consulta.ToListAsync());
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ProductoDTO> Obtener(Guid id)
        {
            try
            {
                // Consultamos por el usuario con el Id proporcionado
                var consulta = _modeloRepositorio.Consultar(p => p.IdProducto == id);
                var fromDbModelo = await consulta.FirstOrDefaultAsync();

                // Verificamos si no encontramos ningún resultado
                if (fromDbModelo == null)
                {
                    // Aquí puedes manejarlo lanzando una excepción o devolviendo null
                    throw new KeyNotFoundException("No se encontró un usuario con el ID proporcionado.");
                }

                // Si encontramos el usuario, lo mapeamos a DTO
                return _mapper.Map<ProductoDTO>(fromDbModelo);
            }
            catch (Exception ex)
            {
                // Aquí puedes manejar el error según sea necesario (log, rethrow, etc.)
                throw new Exception("Error al obtener el usuario: " + ex.Message, ex);
            }
        }

       
    }
}
