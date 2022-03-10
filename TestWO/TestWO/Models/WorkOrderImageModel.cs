using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWO.Models
{
    public class WorkOrderImageModel
    {
        public ImageModel Image { get; set; }

        public string ImageFileName { get; set; }

        public byte[] ImageData { get; set; }
    }   
}
