﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace OFOP.Entity.Models
{
    public partial class MenuType
    {
        public MenuType()
        {
            Menu = new HashSet<Menu>();
        }

        public int MenuTypeId { get; set; }
        public string TypeName { get; set; }

        public virtual ICollection<Menu> Menu { get; set; }
    }
}