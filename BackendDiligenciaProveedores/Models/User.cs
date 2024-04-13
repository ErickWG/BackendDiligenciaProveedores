using System;
using System.Collections.Generic;

namespace BackendDiligenciaProveedores.Models;

public partial class User
{
    public int UsuarioId { get; set; }

    public string? Usuario { get; set; }

    public string? Contrasenia { get; set; }

    public string? Rol { get; set; }
}
