using System;
using System.Collections.Generic;

namespace OFOP.Entity.Models;

public partial class Menu
{
    public int MenuId { get; set; }

    public string MenuName { get; set; }

    public int MenuTypeId { get; set; }

    public decimal Price { get; set; }

    public string MenuImage { get; set; }

    public string Ingredients { get; set; }

    public bool MenuActive { get; set; }

    public virtual MenuType MenuType { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Rating> Ratings { get; set; } = new List<Rating>();
}
