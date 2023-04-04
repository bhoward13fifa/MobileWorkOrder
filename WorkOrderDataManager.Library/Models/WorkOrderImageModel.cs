using System;
using System.Collections.Generic;
using System.Text;

namespace WorkOrderDataManager.Library.Models
{
    public class WorkOrderImageModel
    {
        public ImageModel Image { get; set; }
        public int WorkOrderId { get; set; }

        public string ImageFileName { get; set; }

        public byte[] ImageData { get; set; }
    }
}
