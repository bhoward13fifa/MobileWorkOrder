using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkOrderDataManager.Library.Models
{
    public class WorkOrderDetailsDBModel
    {
        public int WorkOrderId { get; set; }

        public string ProductId { get; set; }

        public int CustomerId { get; set; }

        public int ProductQuantity { get; set; }

        public byte[] Image { get; set; }
    }
}
