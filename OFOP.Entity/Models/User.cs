using System;
using System.Collections.Generic;

namespace OFOP.Entity.Models;

public partial class User
{
    public int CustId { get; set; }

    public string CustName { get; set; }

    public string CustUsername { get; set; }

    public string CustPassword { get; set; }

    public string CustTelNumber { get; set; }

    public string CustAddress { get; set; }

    public string CustPostCode { get; set; }

    public string CustEmail { get; set; }

    public int UserType { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Rating> Ratings { get; set; } = new List<Rating>();

    public virtual UserType UserTypeNavigation { get; set; }
}
