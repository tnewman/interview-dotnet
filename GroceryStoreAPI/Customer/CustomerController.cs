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
        CustomerRepository customerRepository;

        public CustomerController(CustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Customer>> List()
        {
            return Ok(this.customerRepository.List());
        }

        [HttpGet("{id}")]
        public ActionResult<Customer> Get(int id)
        {
            Customer customer = this.customerRepository.Get(id);

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }
    }
}
