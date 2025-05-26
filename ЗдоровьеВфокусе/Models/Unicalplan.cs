using System;
using System.Collections.Generic;

namespace ЗдоровьеВфокусе.Models;

public partial class Unicalplan
{
    public int Id { get; set; }

    public int? Day { get; set; }

    public bool? End { get; set; }

    public int? Iduser { get; set; }

    public int? Soisokupr { get; set; }
}
