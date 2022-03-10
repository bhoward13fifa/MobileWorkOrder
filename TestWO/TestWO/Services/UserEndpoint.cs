using TestWO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using TestWO.Services;

[assembly: Dependency(typeof(UserEndpoint))]
namespace TestWO.Services
{
    public class UserEndpoint : IUserEndpoint
    {
        private IAPIHelper _apiHelper;

        public UserEndpoint()
        {
            _apiHelper = DependencyService.Get<IAPIHelper>();
        }

        public async Task<List<UserModel>> GetAll()
        {
            using (HttpResponseMessage response = await _apiHelper.ApiClient.GetAsync("/api/User"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<List<UserModel>>();
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
