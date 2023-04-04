using System;
using System.Collections.Generic;
using System.Text;

namespace TestWO.Models
{
    public class WorkOrderDBModel
    {
        public int WorkOrderId { get; set; }
        public string WorkDescription { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string UserId { get; set; }
        public int CustomerId { get; set; }
    }
}
