using System;
using System.Collections.Generic;

namespace AbiruAPI.Models;

public partial class UsuarioSearch
{
    public int IdUs { get; set; }

    public int? IdUsuario { get; set; }

    public int? IdColegio { get; set; }

    public virtual Colegio? IdColegioNavigation { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
