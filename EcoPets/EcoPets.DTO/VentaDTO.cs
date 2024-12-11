using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoPets.DTO
{
    public class VentaDTO
    {
        public Guid IdVenta { get; set; }

        public Guid? IdUsuario { get; set; }

        public decimal? Total { get; set; }


        public virtual ICollection<DetalleVentaDTO> DetalleVenta { get; set; } = new List<DetalleVentaDTO>();

    }
}
