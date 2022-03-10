using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWO.Models
{
    public class WorkOrderModel
    {
        public List<WorkOrderDetailsModel> WorkOrderDetails { get; set; } = new List<WorkOrderDetailsModel>();
    }
}
