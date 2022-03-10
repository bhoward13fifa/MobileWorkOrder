using TestWO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using TestWO.Services;

[assembly: Dependency(typeof(CustomerEndpoint))]
namespace TestWO.Services
{
    public class CustomerEndpoint : ICustomerEndpoint
    {
        private IAPIHelper _apiHelper;

        public CustomerEndpoint()
        {
            _apiHelper = DependencyService.Get<IAPIHelper>();
        }

        public async Task<List<CustomerModel>> GetAll()
        {
            using (HttpResponseMessage response = await _apiHelper.ApiClient.GetAsync("/api/Customer"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<List<CustomerModel>>();
                    return result;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
