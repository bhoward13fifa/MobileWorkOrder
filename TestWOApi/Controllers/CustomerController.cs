using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WorkOrderDataManager.Library.DataAccess;
using WorkOrderDataManager.Library.Models;

namespace TestWOApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CustomerController : ControllerBase
    {
        private readonly IConfiguration _config;
        public CustomerController(IConfiguration config)
        {
            _config = config;
        }
        [HttpGet]
        public List<CustomerModel> Get()
        {
            CustomerData data = new CustomerData(_config);

            return data.GetCustomers();

        }
    }
}
