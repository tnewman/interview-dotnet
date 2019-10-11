using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace GroceryStoreAPI.Customer
{
    public interface ICustomerController
    {
        IEnumerable<Customer> List();

        ActionResult<Customer> Get(int id);

        ActionResult<Customer> Save([FromBody] Customer customer);
    }

    [Route("api/customer")]
    [ApiController]
    public class CustomerController : ControllerBase, ICustomerController
    {
        ICustomerRepository customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        [HttpGet]
        public IEnumerable<Customer> List()
        {
            return this.customerRepository.List();
        }

        [HttpGet("{id}")]
        public ActionResult<Customer> Get(int id)
        {
            Customer customer = this.customerRepository.Get(id);

            if (customer == null)
            {
                return NotFound();
            }

            return customer;
        }

        [HttpPost]
        public ActionResult<Customer> Save([FromBody] Customer customer)
        {
            Customer savedCustomer = this.customerRepository.Save(customer);

            return savedCustomer;
        }
    }
}
