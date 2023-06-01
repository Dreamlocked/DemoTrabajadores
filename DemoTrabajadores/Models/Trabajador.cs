using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace DemoTrabajadores.Models;

public partial class Trabajador
{
    public int IdTrabajador { get; set; }

    public string? TipoDocumento { get; set; }

    public string? NroDocumento { get; set; }

    public string? Nombres { get; set; }

    public string? Sexo { get; set; }

    public int? IdDistrito { get; set; }

    public virtual Distrito IdDistritoNavigation { get; set; } = null!;
}
