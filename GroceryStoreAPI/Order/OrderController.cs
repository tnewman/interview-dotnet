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
        public ActionResult<IEnumerable<Order>> List()
        {
            return Ok(this.jsonDatabase.loadJSONData().Orders);
        }

        [HttpGet("{id}")]
        public ActionResult<Order> Get(int id)
        {
            Order order = this.jsonDatabase
                .loadJSONData()
                .Orders
                .Where(o => o.Id == id)
                .FirstOrDefault();

            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }

        [HttpGet("customer/{customerId}")]
        public ActionResult<IEnumerable<Order>> GetByCustomer(int customerId)
        {
            IEnumerable<Order> orders = this.jsonDatabase
                .loadJSONData()
                .Orders
                .Where(o => o.CustomerId == customerId);

            return Ok(orders);
        }

        [HttpGet("date/{date}")]
        public ActionResult<IEnumerable<Order>> GetByDate(DateTime date)
        {
            IEnumerable<Order> orders = this.jsonDatabase
                .loadJSONData()
                .Orders
                .Where(o => o.Date == date);

            return Ok(orders);
        }
    }
}
