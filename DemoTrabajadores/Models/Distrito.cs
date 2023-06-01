using System;
using System.Collections.Generic;

namespace DemoTrabajadores.Models;

public partial class Distrito
{
    public int IdDistrito { get; set; }

    public int IdProvincia { get; set; }

    public string? NombreDistrito { get; set; }

    public virtual Provincia IdProvinciaNavigation { get; set; } = null!;

    public virtual ICollection<Trabajador> Trabajadors { get; set; } = new List<Trabajador>();
}
