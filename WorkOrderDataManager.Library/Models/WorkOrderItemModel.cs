using System;
using System.Collections.Generic;
using System.Text;

namespace WorkOrderDataManager.Library.Models
{
    public class WorkOrderItemModel
    {
        public ProductModel Product { get; set; }
        public string ProductId { get; set; }

        public int ProductQuantity { get; set; }
    }
}
