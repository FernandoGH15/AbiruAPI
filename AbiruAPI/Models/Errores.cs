using System;
using System.Collections.Generic;

namespace AbiruAPI.Models;

public partial class Errores
{
    public int IdError { get; set; }

    public DateTime? Fecha { get; set; }

    public string? Titulo { get; set; }

    public string? Descripcion { get; set; }
}
