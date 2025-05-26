using System;
using System.Collections.Generic;

namespace ЗдоровьеВфокусе.Models;

public partial class Gender
{
    public int Id { get; set; }

    public string? Genders { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
