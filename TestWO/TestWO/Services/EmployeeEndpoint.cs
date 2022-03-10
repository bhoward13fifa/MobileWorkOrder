using TestWO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using TestWO.Services;

[assembly: Dependency(typeof(EmployeeEndpoint))]
namespace TestWO.Services
{
    public class EmployeeEndpoint : IEmployeeEndpoint
    {
        private IAPIHelper _apiHelper;

        public EmployeeEndpoint()
        {
            _apiHelper = DependencyService.Get<IAPIHelper>();
        }

        public async Task<List<EmployeeModel>> GetAll()
        {
            using (HttpResponseMessage response = await _apiHelper.ApiClient.GetAsync("/api/Employee"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<List<EmployeeModel>>();
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
