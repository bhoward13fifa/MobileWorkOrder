﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWO.Models
{
    public class WorkOrderItemModel
    {
        public ProductModel Product { get; set; }

        public int ProductQuantity { get; set; }
    }
}
