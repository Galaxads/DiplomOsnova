using System;
using System.Collections.Generic;

namespace ЗдоровьеВфокусе.Models;

public partial class User
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? Biodate { get; set; }

    public int? Gender { get; set; }

    public int? Achivment { get; set; }

    public int? Plansport { get; set; }

    public virtual Achivlist? AchivmentNavigation { get; set; }

    public virtual Listbioinf? BiodateNavigation { get; set; }

    public virtual Gender? GenderNavigation { get; set; }

    public virtual Listtrenirov? PlansportNavigation { get; set; }
}
