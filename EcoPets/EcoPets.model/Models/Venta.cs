using System;
using System.Collections.Generic;

namespace EcoPets.model.Models;

public partial class Venta
{
    public Guid IdVenta { get; set; }

    public Guid? IdUsuario { get; set; }

    public decimal? Total { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual ICollection<DetalleVenta> DetalleVenta { get; set; } = new List<DetalleVenta>();

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
