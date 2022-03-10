using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WorkOrderDataManager.Library.Models;
using WorkOrderDataManager.Library.DataAccess;

namespace TestWOApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmployeeController : ControllerBase
    {
        private readonly IConfiguration _config;
        public EmployeeController(IConfiguration config)
        {
            _config = config;
        }
        [HttpGet]
        public List<EmployeeModel> Get()
        {
            EmployeeData data = new EmployeeData(_config);

            return data.GetEmployees();

        }
    }
}
