using EcoPets.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EcoPets.DTO;

namespace EcoPets.servicio.Contrato
{
    public interface IProductoServicio
    {
        Task<List<ProductoDTO>> Lista(string buscar);
        Task<List<ProductoDTO>> Catalogo(string categoria, string buscar);
        Task<ProductoDTO> Obtener(Guid id);
        Task<ProductoDTO> Crear(ProductoDTO modelo);

        Task<bool> Editar(ProductoDTO modelo);
        Task<bool> Eliminar(Guid id);

    }
}
