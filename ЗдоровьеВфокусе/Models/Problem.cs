using System;
using System.Collections.Generic;

namespace ЗдоровьеВфокусе.Models;

public partial class Problem
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Problemslist> Problemslists { get; set; } = new List<Problemslist>();
}
