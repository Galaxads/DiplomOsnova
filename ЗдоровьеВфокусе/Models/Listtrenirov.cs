using System;
using System.Collections.Generic;

namespace ЗдоровьеВфокусе.Models;

public partial class Listtrenirov
{
    public int Id { get; set; }

    public int? Listuser { get; set; }

    public int? Listupr { get; set; }

    public virtual Exercise? ListuprNavigation { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
