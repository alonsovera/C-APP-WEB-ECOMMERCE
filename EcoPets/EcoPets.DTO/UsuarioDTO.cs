using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoPets.DTO
{
    public class UsuarioDTO
    {
        public Guid IdUsuario { get; set; }

        public int? IdTipoDocumento { get; set; }
        [Required(ErrorMessage = "Ingrese nombre")]

        public string? Nombre { get; set; }
        [Required(ErrorMessage = "Ingrese apellido")]

        public string? Apellido { get; set; }
        [Required(ErrorMessage = "Ingrese correo")]

        public string? Correo { get; set; }
        [Required(ErrorMessage = "Ingrese contraseña")]


        public string? Clave { get; set; }
        [Required(ErrorMessage = "Ingrese confirmar contraseña")]

        public string? ConfirmarClave { get; set; }


        public string? Rol { get; set; }


    }
}
