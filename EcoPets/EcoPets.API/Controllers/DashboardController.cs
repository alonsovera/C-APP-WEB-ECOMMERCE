using EcoPets.DTO;
using EcoPets.servicio.Contrato;
using EcoPets.servicio.Implementacion;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcoPets.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardService _dashboardService;
        public DashboardController(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;    
        }
        
        [HttpGet("Resumen")]
        public  IActionResult Resumen()
        {
            var response = new ResponseDTO<DashboardDTO>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado =  _dashboardService.Resumen();
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
