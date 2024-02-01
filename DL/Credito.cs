using System;
using System.Collections.Generic;

namespace DL;

public partial class Credito
{
    public int CodCredito { get; set; }

    public int CodCliente { get; set; }

    public int IdTipoCredito { get; set; }

    public bool Activo { get; set; }

    public decimal Monto { get; set; }

    public DateTime FechaInicio { get; set; }

    public DateTime FechaVencimiento { get; set; }

    public virtual Cliente CodClienteNavigation { get; set; } = null!;

    public virtual TipoCredito IdTipoCreditoNavigation { get; set; } = null!;
}
