using System;
using System.Collections.Generic;

namespace AbiruAPI.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public decimal? Dni { get; set; }

    public int? Distrito { get; set; }

    public string? Correo { get; set; }

    public string? Pass { get; set; }

    public string? Categoria { get; set; }

    public virtual Distrito? DistritoNavigation { get; set; }

    public virtual ICollection<Reclamo> Reclamos { get; } = new List<Reclamo>();

    public virtual ICollection<UsuarioSearch> UsuarioSearches { get; } = new List<UsuarioSearch>();
}
