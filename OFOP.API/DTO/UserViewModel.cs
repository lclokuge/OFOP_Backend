using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OFOP.API.DTO
{
    public class UserViewModel
    {
        public string CustName { get; set; }

        public string CustUsername { get; set; }

        public string CustPassword { get; set; }

        public int CustTelNumber { get; set; }

        public string CustAddress { get; set; }

        public string CustPostCode { get; set; }

        public string CustEmail { get; set; }

        public int UserType { get; set; }
    }
}
