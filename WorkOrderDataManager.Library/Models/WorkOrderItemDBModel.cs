using System;
using System.Collections.Generic;
using System.Text;

namespace WorkOrderDataManager.Library.Models
{
    public class WorkOrderItemDBModel
    {
        public int WorkOrderId { get; set; }

        public string ProductId { get; set; }

        public int ProductQuantity { get; set; }
    }
}
