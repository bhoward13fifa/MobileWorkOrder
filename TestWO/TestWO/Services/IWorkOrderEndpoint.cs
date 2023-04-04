using TestWO.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace TestWO.Services
{
    public interface IWorkOrderEndpoint
    {
        Task PostWorkOrder(WorkOrderModel workOrder);

        Task<List<WorkOrderDBModel>> GetAllWorkOrders();
    }
}