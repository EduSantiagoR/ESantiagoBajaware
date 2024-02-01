using System;
using System.Collections.Generic;

namespace DL;

public partial class Cliente
{
    public int CodCliente { get; set; }

    public string Nombre { get; set; } = null!;

    public string ApellidoPaterno { get; set; } = null!;

    public string? ApellidoMaterno { get; set; }

    public DateTime? FechaNacimiento { get; set; }

    public int IdEstadoCivil { get; set; }

    public int IdNacionalidad { get; set; }

    public virtual ICollection<Credito> Creditos { get; set; } = new List<Credito>();

    public virtual EstadoCivil IdEstadoCivilNavigation { get; set; } = null!;

    public virtual Nacionalidad IdNacionalidadNavigation { get; set; } = null!;
}
