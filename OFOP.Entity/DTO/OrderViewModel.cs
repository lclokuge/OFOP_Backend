using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OFOP.Entity.DTO
{
    public class OrderViewModel
    {
        public int CustId { get; set; }
        public decimal TotAmount { get; set; }
        public int MenuId { get; set; }
        public int Qty { get; set; }
    }
}
