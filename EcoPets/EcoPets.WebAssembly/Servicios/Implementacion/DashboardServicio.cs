using EcoPets.DTO;
using EcoPets.WebAssembly.Servicios.Contrato;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Reflection;

namespace EcoPets.WebAssembly.Servicios.Implementacion
{
    public class DashboardServicio : IDashboardServicio
    {
        private readonly HttpClient _httpClient;

        public DashboardServicio(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ResponseDTO<DashboardDTO>> Resumen()
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<DashboardDTO>>("Dashboard/Resumen");
        }
    }
}
