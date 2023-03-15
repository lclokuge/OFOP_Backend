using System;
using System.Collections.Generic;

namespace OFOP.Entity.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public int CustId { get; set; }

    public DateTime OrderDate { get; set; }

    public decimal TotAmount { get; set; }

    public bool OrderStatus { get; set; }

    public bool IsPaid { get; set; }

    public int MenuId { get; set; }

    public int StatusId { get; set; }

    public int Qty { get; set; }

    public virtual User Cust { get; set; }

    public virtual Menu Menu { get; set; }

    public virtual OrderStatus Status { get; set; }
}
