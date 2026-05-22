using System;
using System.Collections.Generic;

namespace PWSAPIServer.Models;

public partial class TbDepartamento
{
    public int IdDepartamento { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<TbEmpleado> TbEmpleados { get; set; } = new List<TbEmpleado>();
}
