using System;
using System.Collections.Generic;

namespace AbiruAPI.Models;

public partial class Reclamo
{
    public int IdReclamo { get; set; }

    public string? Titulo { get; set; }

    public string? Descripcion { get; set; }

    public int? IdUsuario { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
