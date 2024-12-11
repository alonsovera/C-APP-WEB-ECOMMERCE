using System;
using System.Collections.Generic;

namespace EcoPets.model.Models;

public partial class TipoDocumento
{
    public int IdTipoDocumento { get; set; }

    public string? CTipoDocumento { get; set; }

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
