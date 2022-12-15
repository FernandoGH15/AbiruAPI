using System;
using System.Collections.Generic;

namespace AbiruAPI.Models;

public partial class Colegio
{
    public int IdColegio { get; set; }

    public string? Nombre { get; set; }

    public string? ImagenPrinc { get; set; }

    public int? Distrito { get; set; }

    public int? Vacantes { get; set; }

    public string? Grado { get; set; }

    public string? Tipo { get; set; }

    public string? Genero { get; set; }

    public decimal? Costo { get; set; }

    public int? Valoracion { get; set; }

    public string? Direccion { get; set; }

    public decimal? DireccionX { get; set; }

    public decimal? DireccionY { get; set; }

    public string? Informacion { get; set; }

    public string? Mision { get; set; }

    public string? Vision { get; set; }

    public string? ImagenInfo { get; set; }

    public string? ResenaA { get; set; }

    public string? ResenaB { get; set; }

    public string? ImagenResA { get; set; }

    public string? ImagenResB { get; set; }

    public string? Religion { get; set; }

    public string? MallaCurricular { get; set; }

    public string? Horario { get; set; }

    public string? Reconocimiento { get; set; }

    public string? ImagenRecoA { get; set; }

    public string? ImagenRecoB { get; set; }

    public string? ImagenRecoC { get; set; }

    public string? ImagenDirect { get; set; }

    public int? ImagenFor { get; set; }

    public virtual Distrito? DistritoNavigation { get; set; }

    public virtual ICollection<UsuarioSearch> UsuarioSearches { get; } = new List<UsuarioSearch>();
}
