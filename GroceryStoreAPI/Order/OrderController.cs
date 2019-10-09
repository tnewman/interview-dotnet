using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroceryStoreAPI.JSON;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GroceryStoreAPI.Order
{
    [Route("api/order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        JSONDatabase jsonDatabase;

        public OrderController(JSON.JSONDatabase jsonDatabase)
        {
            this.jsonDatabase = jsonDatabase;
        }

        [HttpGet]
        public IEnumerable<Order> List()
        {
            return this.jsonDatabase.loadJSONData().Orders;
        }
    }
}
