using System;
using System.Collections.Generic;

namespace AbiruAPI.Models;

public partial class Reconocimiento
{
    public int IdReconoce { get; set; }

    public int? IdCole { get; set; }

    public string? Nombre { get; set; }

    public string? Imagen { get; set; }

    public virtual Colegio? IdColeNavigation { get; set; }
}
