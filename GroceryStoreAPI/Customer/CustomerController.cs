using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GroceryStoreAPI.JSON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStoreAPI.Customer
{
    [Route("api/customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        JSONDatabase jsonDatabase;

        public CustomerController(JSON.JSONDatabase jsonDatabase)
        {
            this.jsonDatabase = jsonDatabase;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Customer>> List()
        {
            return Ok(this.jsonDatabase.loadJSONData().Customers);
        }

        [HttpGet("{id}")]
        public ActionResult<Customer> Get(int id)
        {
            Customer customer = this.jsonDatabase
                .loadJSONData()
                .Customers
                .Where(c => c.Id == id)
                .FirstOrDefault();

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }
    }
}
