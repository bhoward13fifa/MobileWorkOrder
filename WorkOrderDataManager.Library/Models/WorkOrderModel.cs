using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorkOrderDataManager.Library.Models
{
    public class WorkOrderModel
    {
        public string WorkDescription { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int CustomerId { get; set; }
        public List<WorkOrderEmployeeModel> WorkOrderEmployee { get; set; } = new List<WorkOrderEmployeeModel>();

        public List<WorkOrderImageModel> WorkOrderImage { get; set; } = new List<WorkOrderImageModel>();
        public List<WorkOrderItemModel> WorkOrderItem { get; set; } = new List<WorkOrderItemModel>();
    }
}