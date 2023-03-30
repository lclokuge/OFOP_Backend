using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OFOP.Entity.DTO
{
    public class MenuModel
    {
        public int MenuId { get; set; }
        public string MenuName { get; set; }
        public int MenuTypeId { get; set; }
        public decimal Price { get; set; }
        public byte[] MenuImage { get; set; }
        public string Ingredients { get; set; }
        public bool MenuActive { get; set; }
        public DateTime MenuCreatedDate { get; set; }
        public int Cook { get; set; }
    }
}
