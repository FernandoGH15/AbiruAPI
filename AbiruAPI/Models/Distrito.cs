using System;
using System.Collections.Generic;

namespace AbiruAPI.Models;

public partial class Distrito
{
    public int IdDist { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<Colegio> Colegios { get; } = new List<Colegio>();

    public virtual ICollection<Usuario> Usuarios { get; } = new List<Usuario>();
}
