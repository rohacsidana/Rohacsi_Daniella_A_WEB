using System;
using System.Collections.Generic;

namespace vizsga_alap_backend.Models;

public partial class Teszt
{
    public int Id { get; set; }

    public string Kerdes { get; set; } = null!;

    public string V1 { get; set; } = null!;

    public string V2 { get; set; } = null!;

    public string V3 { get; set; } = null!;

    public string V4 { get; set; } = null!;

    public string? Helyes { get; set; }

    public int KategoriaId { get; set; }

    public DateTime? Timestamps { get; set; }

    public virtual Kategorium Kategoria { get; set; } = null!;
}
