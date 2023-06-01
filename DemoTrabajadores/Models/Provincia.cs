using System;
using System.Collections.Generic;

namespace DemoTrabajadores.Models;

public partial class Provincia
{
    public int IdProvincia { get; set; }

    public int IdDepartamento { get; set; }

    public string? NombreProvincia { get; set; }

    public virtual ICollection<Distrito> Distritos { get; set; } = new List<Distrito>();

    public virtual Departamento IdDepartamentoNavigation { get; set; } = null!;
}
