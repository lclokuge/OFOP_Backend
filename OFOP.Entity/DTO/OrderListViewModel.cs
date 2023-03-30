using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OFOP.Entity.DTO
{
    public class OrderListViewModel
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotAmount { get; set; }
        
        public string Status { get; set; }
        public int Qty { get; set; }

        public int MenuId { get; set; }
        public string MenuName { get; set; }
        public decimal Price { get; set; }
        public byte[] MenuImage { get; set; }

        public int CustId { get; set; }

        public string CustName { get; set; }

        public string CustTelNumber { get; set; }

        public string CustAddress { get; set; }

        public string CustPostCode { get; set; }


    }
}
