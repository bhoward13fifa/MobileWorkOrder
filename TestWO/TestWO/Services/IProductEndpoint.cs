using TestWO.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestWO.Services
{
    public interface IProductEndpoint
    {
        Task<List<ProductModel>> GetAll();
    }
}