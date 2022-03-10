  using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWO.Models
{
    public class EmployeeModel
    {
        public int EmployeeId { get; set; }
        public string EmployeeFirstName { get; set; }
        public string EmployeeLastName { get; set; }
        public string SelectionName
        {
            get
            {
                return $"{ EmployeeFirstName } { EmployeeLastName }";
            }
        }

    }
}
