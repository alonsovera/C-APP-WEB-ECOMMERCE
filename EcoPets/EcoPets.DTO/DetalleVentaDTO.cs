﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoPets.DTO
{
    public class DetalleVentaDTO
    {
        public int IdDetalleVenta { get; set; }


        public Guid? IdProducto { get; set; }

        public int? Cantidad { get; set; }

        public decimal? Total { get; set; }

        //public virtual TipoComprobanteDTO? IdTipoComprobanteNavigation { get; set; }

    }
}
