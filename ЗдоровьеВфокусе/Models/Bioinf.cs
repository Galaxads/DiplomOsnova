using System;
using System.Collections.Generic;

namespace ЗдоровьеВфокусе.Models;

public partial class Bioinf
{
    public int Id { get; set; }

    public int? Rost { get; set; }

    public int? Ves { get; set; }

    public DateOnly? Date { get; set; }

    public float? Kolvovater { get; set; }

    public virtual ICollection<Listbioinf> Listbioinfs { get; set; } = new List<Listbioinf>();
}
