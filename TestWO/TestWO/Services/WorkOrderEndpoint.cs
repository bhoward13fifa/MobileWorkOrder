using TestWO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using TestWO.Services;

[assembly: Dependency(typeof(WorkOrderEndpoint))]
namespace TestWO.Services
{
    public class WorkOrderEndpoint : IWorkOrderEndpoint
    {
        private IAPIHelper _apiHelper;

        public WorkOrderEndpoint()
        {
            _apiHelper = DependencyService.Get<IAPIHelper>();
        }

        public async Task PostWorkOrder(WorkOrderModel workOrder)
        {
            using (HttpResponseMessage response = await _apiHelper.ApiClient.PostAsJsonAsync("/api/WorkOrder", workOrder))
            {
                if (response.IsSuccessStatusCode)
                {
                    // Log successful call?
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
