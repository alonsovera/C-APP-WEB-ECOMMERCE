﻿using EcoPets.DTO;

namespace EcoPets.WebAssembly.Servicios.Contrato
{
    public interface IProductoServicio
    {
        Task<ResponseDTO<List<ProductoDTO>>> Lista( string buscar);
        Task<ResponseDTO<List<ProductoDTO>>> Catalogo(string categoria, string buscar);

        Task<ResponseDTO<ProductoDTO>> Obtener(Guid id);

        Task<ResponseDTO<ProductoDTO>> Crear(ProductoDTO modelo);

        Task<ResponseDTO<bool>> Editar(ProductoDTO modelo);
        Task<ResponseDTO<bool>> Eliminar(Guid id);
    }
}
