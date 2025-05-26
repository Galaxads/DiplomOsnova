using System;
using System.Collections.Generic;

namespace ЗдоровьеВфокусе.Models;

public partial class Achivka
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? Condition { get; set; }

    public string? Image { get; set; }

    public bool? End { get; set; }

    public virtual ICollection<Achivlist> Achivlists { get; set; } = new List<Achivlist>();
}
