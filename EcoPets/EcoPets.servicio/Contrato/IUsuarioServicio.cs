using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EcoPets.DTO;

namespace EcoPets.servicio.Contrato
{
    public interface IUsuarioServicio
    {
        Task<List<UsuarioDTO>> Lista(string rol, string buscar);

        Task<UsuarioDTO> Obtener(Guid id);
        Task<SesionDTO> Autorizacion(LoginDTO modelo);
        Task<UsuarioDTO> Crear(UsuarioDTO modelo);

        Task<bool> Editar(UsuarioDTO modelo);
        Task<bool> Eliminar(Guid id);
         



    }
}
