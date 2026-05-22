using System;
using System.Collections.Generic;

namespace PWSAPIServer.Models;

public partial class TbEmpleado
{
    public int IdEmpleado { get; set; }

    public string NombreCompleto { get; set; } = null!;

    public int IdDepartamento { get; set; }

    public int Sueldo { get; set; }

    public DateTime FechaContrato { get; set; }

    public virtual TbDepartamento IdDepartamentoNavigation { get; set; } = null!;
}
