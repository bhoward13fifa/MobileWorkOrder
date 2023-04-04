using System;
using System.Collections.Generic;
using System.Text;

namespace WorkOrderDataManager.Library.Models
{
    public class WorkOrderImageDBModel
    {
        public int ImageId { get; set; }
        public int WorkOrderId { get; set; }
        public string ImageFileName { get; set; }
        public byte[] ImageData { get; set; }

    }
}
