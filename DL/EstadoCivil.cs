using System;
using System.Collections.Generic;

namespace DL;

public partial class EstadoCivil
{
    public int IdEstadoCivil { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();
}
