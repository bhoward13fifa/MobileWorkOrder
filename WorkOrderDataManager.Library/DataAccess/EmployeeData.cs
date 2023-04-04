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
    public class EmployeeData
    {
        private readonly IConfiguration _config;
        public EmployeeData(IConfiguration config)
        {
            _config = config;
        }
        public List<EmployeeModel> GetEmployees()
        {
            SqlDataAccess sql = new SqlDataAccess(_config);

            var output = sql.LoadData<EmployeeModel, dynamic>("dbo.spEmployee_Lookup", new { }, "WorkOrderData");

            return output;
        }
        public EmployeeModel GetEmployeeById(int employeeId)
        {
            SqlDataAccess sql = new SqlDataAccess(_config);

            var output = sql.LoadData<EmployeeModel, dynamic>("dbo.spEmployees_GetById", new { Id = employeeId }, "WorkOrderData").FirstOrDefault();

            return output;
        }
    }
}
