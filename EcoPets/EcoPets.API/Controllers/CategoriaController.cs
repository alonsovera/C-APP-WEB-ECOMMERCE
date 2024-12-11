using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using EcoPets.servicio.Contrato;
using EcoPets.DTO;
using EcoPets.servicio.Implementacion;

namespace EcoPets.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaServicio _categoriServicio;

        public CategoriaController(ICategoriaServicio categoriServicio)
        {
            _categoriServicio = categoriServicio;
        }


        [HttpGet("Lista/{buscar?}")]
        public async Task<IActionResult> Lista( string buscar = "NA")
        {
            var response = new ResponseDTO<List<CategoriaDTO>>();

            try
            {
                if (buscar == "NA")
                {
                    buscar = "";
                }
                response.EsCorrecto = true;
                response.Resultado = await _categoriServicio.Lista( buscar);
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }


        [HttpGet("Obtener/{Id:int}")]
        public async Task<IActionResult> Obtener(int Id)
        {
            var response = new ResponseDTO<CategoriaDTO>();

            try
            {

                response.EsCorrecto = true;
                response.Resultado = await _categoriServicio.Obtener(Id);
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }


        [HttpPost("Crear")]
        public async Task<IActionResult> Crear([FromBody] CategoriaDTO modelo)
        {
            var response = new ResponseDTO<CategoriaDTO>();

            try
            {

                response.EsCorrecto = true;
                response.Resultado = await _categoriServicio.Crear(modelo);
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpPut("Editar")]
        public async Task<IActionResult> Editar([FromBody] CategoriaDTO modelo)
        {
            var response = new ResponseDTO<bool>();

            try
            {

                response.EsCorrecto = true;
                response.Resultado = await _categoriServicio.Editar(modelo);
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpDelete("Eliminar/{Id:int}")]
        public async Task<IActionResult> Eliminar(int Id)
        {
            var response = new ResponseDTO<bool>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _categoriServicio.Eliminar(Id);
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }
    }
}
