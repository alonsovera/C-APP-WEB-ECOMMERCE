using EcoPets.DTO;
using EcoPets.WebAssembly.Servicios.Contrato;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Reflection;

namespace EcoPets.WebAssembly.Servicios.Contrato
{
    public interface ICategoriaServicio
    {
        Task<ResponseDTO<List<CategoriaDTO>>> Lista( string buscar);
        Task<ResponseDTO<CategoriaDTO>> Obtener(int id);

        Task<ResponseDTO<CategoriaDTO>> Crear(CategoriaDTO modelo);

        Task<ResponseDTO<bool>> Editar(CategoriaDTO modelo);
        Task<ResponseDTO<bool>> Eliminar(int id);

    }
}
