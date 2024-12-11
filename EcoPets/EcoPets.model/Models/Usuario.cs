using System;
using System.Collections.Generic;

namespace EcoPets.model.Models;

public partial class Usuario
{
    public Guid IdUsuario { get; set; }

    public int? IdTipoDocumento { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? Correo { get; set; }

    public string? Clave { get; set; }

    public string? Rol { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual TipoDocumento? IdTipoDocumentoNavigation { get; set; }

    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}
