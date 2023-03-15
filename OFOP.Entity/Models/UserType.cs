using System;
using System.Collections.Generic;

namespace OFOP.Entity.Models;

public partial class UserType
{
    public int UtypeId { get; set; }

    public string UtName { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
