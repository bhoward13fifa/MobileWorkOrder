using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWO.Models
{
    public class CustomerModel
    {
        public int CustomerId { get; set; }

        public string CustomerFirstName { get; set; }

        public string CustomerLastName { get; set; }

        public string CustomerName
        {
            get
            {
                return $"{CustomerFirstName} {CustomerLastName}";
            }
        }
    }
}
