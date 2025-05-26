using System;
using System.Collections.Generic;

namespace ЗдоровьеВфокусе.Models;

public partial class Listbioinf
{
    public int Id { get; set; }

    public int? Listuser { get; set; }

    public int? Listbio { get; set; }

    public virtual Bioinf? ListbioNavigation { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
