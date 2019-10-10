using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
