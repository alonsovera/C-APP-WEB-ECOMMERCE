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

namespace EcoPets.servicio.Implementacion
{
    public class UsuarioServicio: IUsuarioServicio
    {
        private readonly IGenericoRepositorio<Usuario> _modeloRepositorio;
        private readonly IMapper _mapper;
        public UsuarioServicio(IGenericoRepositorio<Usuario> modeloRepositorio, IMapper mapper)
        {
            _modeloRepositorio = modeloRepositorio;
            _mapper = mapper;
        }

        public async Task<SesionDTO> Autorizacion(LoginDTO modelo)
        {
            try
            {
                var consulta = _modeloRepositorio.Consultar(p => p.Correo == modelo.Correo && p.Clave == modelo.Clave);
                var fromDbModel = await consulta.FirstOrDefaultAsync();

                if (fromDbModel != null)
                {
                    return _mapper.Map<SesionDTO>(fromDbModel);
                }
                else
                {
                    throw new TaskCanceledException("No se encontraron coincidencias");
                }
            }
            catch (Exception ex) 
            {
                throw ex;
            }
        }

        public async Task<UsuarioDTO> Crear(UsuarioDTO modelo)
        {
            try
            {
               var dbModelo = _mapper.Map<Usuario>(modelo);
               var rspModelo = await _modeloRepositorio.Crear(dbModelo);

                if (rspModelo.IdUsuario != Guid.Empty)
                {
                    return _mapper.Map<UsuarioDTO>(rspModelo);
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

        public async Task<bool> Editar(UsuarioDTO modelo)
        {
            try
            {
                var consulta = _modeloRepositorio.Consultar(p => p.IdUsuario == modelo.IdUsuario);
                var fromDbModelo = await consulta.FirstOrDefaultAsync();

                if (fromDbModelo != null)
                {
                    fromDbModelo.Nombre = modelo.Nombre;
                    fromDbModelo.Apellido = modelo.Apellido;
                    fromDbModelo.Correo = modelo.Correo;
                    fromDbModelo.Clave = modelo.Clave;
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
                var consulta = _modeloRepositorio.Consultar(p => p.IdUsuario == id);
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

        public async Task<List<UsuarioDTO>> Lista(string rol, string buscar)
        {
            try
            {
                var consulta = _modeloRepositorio.Consultar(p =>
                p.Rol == rol &&
                string.Concat(p.Nombre.ToLower(), p.Apellido.ToLower(), p.Correo.ToLower()).Contains(buscar.ToLower())
                );

                List<UsuarioDTO> lista = _mapper.Map<List<UsuarioDTO>>(await consulta.ToListAsync());
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<UsuarioDTO> Obtener(Guid id)
        {
            try
            {
                // Consultamos por el usuario con el Id proporcionado
                var consulta = _modeloRepositorio.Consultar(p => p.IdUsuario == id);
                var fromDbModelo = await consulta.FirstOrDefaultAsync();

                // Verificamos si no encontramos ningún resultado
                if (fromDbModelo == null)
                {
                    // Aquí puedes manejarlo lanzando una excepción o devolviendo null
                    throw new KeyNotFoundException("No se encontró un usuario con el ID proporcionado.");
                }

                // Si encontramos el usuario, lo mapeamos a DTO
                return _mapper.Map<UsuarioDTO>(fromDbModelo);
            }
            catch (Exception ex)
            {
                // Aquí puedes manejar el error según sea necesario (log, rethrow, etc.)
                throw new Exception("Error al obtener el usuario: " + ex.Message, ex);
            }
        }

    }
}
