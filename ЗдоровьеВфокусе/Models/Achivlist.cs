using System;
using System.Collections.Generic;

namespace ЗдоровьеВфокусе.Models;

public partial class Achivlist
{
    public int Id { get; set; }

    public int? IdUser { get; set; }

    public int? IdAchiv { get; set; }

    public virtual Achivka? IdAchivNavigation { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
