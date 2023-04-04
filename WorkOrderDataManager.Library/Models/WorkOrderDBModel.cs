using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkOrderManager.Library.Models
{
    public class WorkOrderDBModel
    {
        public int WorkOrderId { get; set; }
        public string WorkDescription { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string UserId { get; set; }
        public int CustomerId   { get; set; }
    }
}
