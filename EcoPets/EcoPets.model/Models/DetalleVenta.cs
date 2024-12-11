using System;
using System.Collections.Generic;

namespace EcoPets.model.Models;

public partial class DetalleVenta
{
    public int IdDetalleVenta { get; set; }

    public Guid? IdVenta { get; set; }

    public Guid? IdProducto { get; set; }

    public int? Cantidad { get; set; }

    public decimal? Total { get; set; }

    public int? IdTipoComprobante { get; set; }

    public virtual Producto? IdProductoNavigation { get; set; }

    public virtual TipoComprobante? IdTipoComprobanteNavigation { get; set; }

    public virtual Venta? IdVentaNavigation { get; set; }
}
