﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution1.Domain.Entities.Common
{
    public class Product: BaseEntity
    {
        public string Name { get; set; }
        public int Stock { get; set; }
        public int Price { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
