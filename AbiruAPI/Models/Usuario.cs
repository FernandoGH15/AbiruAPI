using System;
using System.Collections.Generic;

namespace AbiruAPI.Models;

public partial class Usuario
{
    public int IdUser { get; set; }

    public string? Nombre { get; set; }

    public string? Dni { get; set; }

    public string? Email { get; set; }

    public int? Distrito { get; set; }

    public string? Pass { get; set; }

    public string? Categoria { get; set; }

    public virtual Distrito? DistritoNavigation { get; set; }

    public virtual ICollection<UsuarioSearch> UsuarioSearches { get; } = new List<UsuarioSearch>();
}
