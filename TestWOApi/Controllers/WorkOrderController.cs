﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WorkOrderDataManager.Library.DataAccess;
using WorkOrderDataManager.Library.Models;
using System.Security.Claims;
using WorkOrderManager.Library.Models;

namespace TestWOApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class WorkOrderController : ControllerBase
    {
        private readonly IConfiguration _config;
        public WorkOrderController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet]
        public List<WorkOrderDBModel> Get()
        {
            WorkOrderData data = new WorkOrderData(_config);

            return data.GetWorkOrders();
        }

        [HttpPost]
        public void Post(WorkOrderModel workOrder)
        {
            WorkOrderData data = new WorkOrderData(_config);
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            data.SaveWorkOrder(workOrder, userId);
        }
    }
}
