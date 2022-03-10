using TestWO.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestWO.Services
{
    public interface ICustomerEndpoint
    {
        Task<List<CustomerModel>> GetAll();
    }
}