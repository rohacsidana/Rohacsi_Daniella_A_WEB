using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace vizsga_alap_backend.Models;

public partial class Kategorium
{
    public int Id { get; set; }

    public string Kategorianev { get; set; } = null!;

    public DateTime? Timestamps { get; set; }

    [JsonIgnore]
    public virtual ICollection<Teszt> Teszts { get; set; } = new List<Teszt>();
}
