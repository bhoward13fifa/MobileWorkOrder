using WorkOrderDataManager.Library.Internal.DataAccess;
using WorkOrderDataManager.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace WorkOrderDataManager.Library.DataAccess
{
    public class CustomerData
    {
        private readonly IConfiguration _config;
        public CustomerData(IConfiguration config)
        {
            _config = config;
        }
        public List<CustomerModel> GetCustomers()
        {
            SqlDataAccess sql = new SqlDataAccess(_config);

            var output = sql.LoadData<CustomerModel, dynamic>("dbo.spCustomer_Lookup", new { }, "WorkOrderData");

            return output;
        }
    }
}
