using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWO.Models
{
    public class WorkOrderEmployeeModel
    {
        public EmployeeModel Employee { get; set; }
        public string DisplayName
        {
            get
            {
                return $"{ Employee.EmployeeFirstName } { Employee.EmployeeLastName }";
            }
        }
    }
}
