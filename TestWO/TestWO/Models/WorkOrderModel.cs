using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWO.Models
{
    public class WorkOrderModel
    {
        public string WorkDescription { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int CustomerId { get; set; }
        public List<WorkOrderEmployeeDBModel> WorkOrderEmployee { get; set; } = new List<WorkOrderEmployeeDBModel>();

        public List<WorkOrderImageModel> WorkOrderImage { get; set; } = new List<WorkOrderImageModel>();
        public List<WorkOrderItemModel> WorkOrderItem { get; set; } = new List<WorkOrderItemModel>();
    }
}
