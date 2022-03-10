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
        public void SaveWorkOrder(WorkOrderModel workOrderInfo, string userId)
        {
            // TODO: Make this SOLID/DRY/BETTER
            // Start filling in the models we will save to the database
            List<WorkOrderDetailsDBModel> details = new List<WorkOrderDetailsDBModel>();
            ProductData products = new ProductData(_config);

            foreach (var item in workOrderInfo.WorkOrderDetails)
            {
                var detail = new WorkOrderDetailsDBModel
                {
                    ProductId = item.ProductId,
                    ProductQuantity = item.ProductQuantity
                };

                var productInfo = products.GetProductById(detail.ProductId);

                if (productInfo == null)
                {
                    throw new Exception($"The product Id of { detail.ProductId } was not found in the database.");
                }

                details.Add(detail);
            }
            // Create the WorkOrder Model
            WorkOrderDBModel workOrder = new WorkOrderDBModel()
            {
                UserId = userId
            };
            // Save the WorkOrder Model
            SqlDataAccess sql = new SqlDataAccess(_config);
            sql.SaveData<WorkOrderDBModel>("dbo.spWorkOrder_Insert", workOrder, "WorkOrderData");
            // Get the ID from the WorkOrder Model
            // Finish filling in the WorkOrderDetails Model
            // Save the WorkOrderDetails Model

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
