using TestWO.Models;
using System.Threading.Tasks;

namespace TestWO.Services
{
    public interface IWorkOrderEndpoint
    {
        Task PostWorkOrder(WorkOrderModel workOrder);
    }
}