using System;
using System.Collections.Generic;

namespace ЗдоровьеВфокусе.Models;

public partial class Problemslist
{
    public int Id { get; set; }

    public int? IdUpr { get; set; }

    public int? IdProbl { get; set; }

    public virtual ICollection<Exercise> Exercises { get; set; } = new List<Exercise>();

    public virtual Problem? IdProblNavigation { get; set; }

    public virtual Exercise? IdUprNavigation { get; set; }
}
