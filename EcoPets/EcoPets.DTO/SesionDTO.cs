using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoPets.DTO
{
    public class SesionDTO
    {
        public Guid IdUsuario { get; set; }

        public int? IdTipoDocumento { get; set; }

        public string? Nombre { get; set; }

        public string? Apellido { get; set; }

        public string? Correo { get; set; }

        public string? Clave { get; set; }

        public string? Rol { get; set; }

    }
}
