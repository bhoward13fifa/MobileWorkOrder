using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorkOrderDataManager.Library.Models
{
    public class WorkOrderModel
    {
        public List<WorkOrderDetailsModel> WorkOrderDetails { get; set; }
    }
}