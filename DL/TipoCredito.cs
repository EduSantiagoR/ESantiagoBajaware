using System;
using System.Collections.Generic;

namespace DL;

public partial class TipoCredito
{
    public int IdTipoCredito { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Credito> Creditos { get; set; } = new List<Credito>();
}
