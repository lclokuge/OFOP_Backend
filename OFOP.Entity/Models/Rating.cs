using System;
using System.Collections.Generic;

namespace OFOP.Entity.Models;

public partial class Rating
{
    public int RatingId { get; set; }

    public int MenuId { get; set; }

    public int Score { get; set; }

    public string Remarks { get; set; }

    public int CustId { get; set; }

    public DateTime DateRecorded { get; set; }

    public virtual User Cust { get; set; }

    public virtual Menu Menu { get; set; }
}
