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
        public IEnumerable<Customer> List()
        {
            return this.jsonDatabase.loadJSONData().Customers;
        }
    }
}
