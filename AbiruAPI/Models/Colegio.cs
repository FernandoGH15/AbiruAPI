﻿using System;
using System.Collections.Generic;

namespace AbiruAPI.Models;

public partial class Colegio
{
    public int IdColegio { get; set; }

    public string? Nombre { get; set; }

    public string? Grado { get; set; }

    public string? Tipo { get; set; }

    public int? Distrito { get; set; }

    public int? Cupos { get; set; }

    public string? Direccion { get; set; }

    public decimal? UbicacionLat { get; set; }

    public decimal? UbicacionLong { get; set; }

    public int? Valoracion { get; set; }

    public string? Matricula { get; set; }

    public string? Resena1 { get; set; }

    public string? Resena2 { get; set; }

    public string? Reconocimientos { get; set; }

    public string? Galeria { get; set; }

    public int? GaleriaNum { get; set; }

    public string? ImagenMain { get; set; }

    public string? MallaCurr { get; set; }

    public decimal? Costo { get; set; }

    public virtual Distrito? DistritoNavigation { get; set; }

    public virtual ICollection<Reconocimiento> ReconocimientosNavigation { get; } = new List<Reconocimiento>();

    public virtual ICollection<UsuarioSearch> UsuarioSearches { get; } = new List<UsuarioSearch>();
}