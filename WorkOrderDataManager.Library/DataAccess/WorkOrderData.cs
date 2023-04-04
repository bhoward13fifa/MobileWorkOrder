using WorkOrderDataManager.Library.Internal.DataAccess;
using WorkOrderDataManager.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkOrderManager.Library.Models;
using Microsoft.Extensions.Configuration;

namespace WorkOrderDataManager.Library.DataAccess
{
    public class WorkOrderData
    {
        private readonly IConfiguration _config;
        public WorkOrderData(IConfiguration config)
        {
            _config = config;
        }

        public List<WorkOrderDBModel> GetWorkOrders()
        {
            SqlDataAccess sql = new SqlDataAccess(_config);

            var output = sql.LoadData<WorkOrderDBModel, dynamic>("dbo.spWorkOrder_GetAll", new { }, "WorkOrderData");

            return output;
        }

        public void SaveWorkOrder(WorkOrderModel workOrderInfo, string userId)
        {
            // TODO: Make this SOLID/DRY/BETTER
            // Start filling in the models we will save to the database
            List<WorkOrderItemDBModel> productDetails = new List<WorkOrderItemDBModel>();
            ProductData products = new ProductData(_config);

            foreach (var item in workOrderInfo.WorkOrderItem)
            {
                var detail = new WorkOrderItemDBModel
                {
                    ProductId = item.ProductId,
                    ProductQuantity = item.ProductQuantity
                };

                var productInfo = products.GetProductById(detail.ProductId);

                if (productInfo == null)
                {
                    throw new Exception($"The product Id of {detail.ProductId} was not found in the database.");
                }

                productDetails.Add(detail);
            }

            List<WorkOrderEmployeeDBModel> employeeDetails = new List<WorkOrderEmployeeDBModel>();
            EmployeeData employees = new EmployeeData(_config);

            foreach (var item in workOrderInfo.WorkOrderEmployee)
            {
                var detail = new WorkOrderEmployeeDBModel
                {
                    EmployeeId = item.EmployeeId
                };

                var employeeInfo = employees.GetEmployeeById(detail.EmployeeId);

                if (employeeInfo == null)
                {
                    throw new Exception($"The employee Id of {detail.EmployeeId} was not found in the database.");
                }

                employeeDetails.Add(detail);
            }

            List<WorkOrderImageDBModel> imageDetails = new List<WorkOrderImageDBModel>();

            foreach (var item in workOrderInfo.WorkOrderImage)
            {
                var detail = new WorkOrderImageDBModel
                {
                    WorkOrderId = item.WorkOrderId,
                    ImageFileName = item.ImageFileName,
                    ImageData = item.ImageData
                };

                imageDetails.Add(detail);
            }
            // Create the WorkOrder Model
            WorkOrderDBModel workOrder = new WorkOrderDBModel()
            {
                WorkDescription = workOrderInfo.WorkDescription,
                StartTime = workOrderInfo.StartTime,
                EndTime = workOrderInfo.EndTime,
                CustomerId = workOrderInfo.CustomerId,
                UserId = userId

            };
            // Save the WorkOrder Model
            SqlDataAccess sql = new SqlDataAccess(_config);
            sql.SaveData("dbo.spWorkOrder_Insert", workOrder, "WorkOrderData");

            // Get the ID from the WorkOrder Model
            workOrder.WorkOrderId = sql.LoadData<int, dynamic>("spWorkOrder_Lookup", new { workOrder.UserId, workOrder.StartTime, workOrder.EndTime }, "WorkOrderData").FirstOrDefault();

            // Finish filling in the WorkOrderDetails Model
            foreach (var item in productDetails)
            {
                item.WorkOrderId = workOrder.WorkOrderId;
                // Save the WorkOrderDetails Model
                sql.SaveData("dbo.spWorkOrderItem_Insert", item, "WorkOrderData");
            }
            foreach (var item in employeeDetails)
            {
                item.WorkOrderId = workOrder.WorkOrderId;
                // Save the WorkOrderDetails Model
                sql.SaveData("dbo.spWorkOrderEmployee_Insert", item, "WorkOrderData");
            }
            foreach (var item in imageDetails)
            {
                item.WorkOrderId = workOrder.WorkOrderId;
                // Save the WorkOrderDetails Model
                sql.SaveData("dbo.spWorkOrderImage_Insert", item, "WorkOrderData");
            }
        }
        //public class ProductData
        //{
        //    public List<ProductModel> GetProducts()
        //    {
        //        SqlDataAccess sql = new SqlDataAccess();

        //        var output = sql.LoadData<ProductModel, dynamic>("dbo.spProducts_Lookup", new { }, "WorkOrderData");

        //        return output;
        //    }
        //}
    }
}
