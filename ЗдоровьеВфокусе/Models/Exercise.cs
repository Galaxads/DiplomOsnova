using System;
using System.Collections.Generic;

namespace ЗдоровьеВфокусе.Models;

public partial class Exercise
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? Image { get; set; }

    public string? Group { get; set; }

    public int? Problems { get; set; }

    public string? Povtorenia { get; set; }

    public string? Slojnost { get; set; }

    public virtual ICollection<Listtrenirov> Listtrenirovs { get; set; } = new List<Listtrenirov>();

    public virtual Problemslist? ProblemsNavigation { get; set; }

    public virtual ICollection<Problemslist> Problemslists { get; set; } = new List<Problemslist>();
}
