using System;
using System.Collections.Generic;

namespace PWSAPIServer.Models;

public partial class TbUsuario
{
    public int IdUsuario { get; set; }

    public string Usuario { get; set; } = null!;

    public string Pass { get; set; } = null!;

    public string Email { get; set; } = null!;

    public bool Activo { get; set; }
}
