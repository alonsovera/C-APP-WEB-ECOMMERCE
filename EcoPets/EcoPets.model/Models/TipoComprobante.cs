using System;
using System.Collections.Generic;

namespace EcoPets.model.Models;

public partial class TipoComprobante
{
    public int IdTipoComprobante { get; set; }

    public string? CTipoComprobante { get; set; }

    public virtual ICollection<DetalleVenta> DetalleVenta { get; set; } = new List<DetalleVenta>();
}
