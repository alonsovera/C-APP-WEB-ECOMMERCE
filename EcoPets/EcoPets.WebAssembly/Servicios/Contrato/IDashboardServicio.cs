using EcoPets.DTO;
using EcoPets.WebAssembly.Servicios.Contrato;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Reflection;


namespace EcoPets.WebAssembly.Servicios.Contrato
{
    public interface IDashboardServicio
    {
        Task<ResponseDTO<DashboardDTO>> Resumen();

    }
}
