using System;
using System.Collections.Generic;

namespace DemoTrabajadores.Models;

public partial class Departamento
{
    public int IdDepartamento { get; set; }

    public string? NombreDepartamento { get; set; }

    public virtual ICollection<Provincia> Provincia { get; set; } = new List<Provincia>();
}
