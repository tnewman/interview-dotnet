using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace GroceryStoreAPI.Order
{
    [Route("api/order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        OrderRepository orderRepository;

        public OrderController(OrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Order>> List()
        {
            return Ok(this.orderRepository.List());
        }

        [HttpGet("{id}")]
        public ActionResult<Order> Get(int id)
        {
            Order order = this.orderRepository.Get(id);

            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }

        [HttpGet("customer/{customerId}")]
        public ActionResult<IEnumerable<Order>> GetByCustomer(int customerId)
        {
            IEnumerable<Order> orders = this.orderRepository.GetByCustomer(customerId);

            return Ok(orders);
        }

        [HttpGet("date/{date}")]
        public ActionResult<IEnumerable<Order>> GetByDate(DateTime date)
        {
            IEnumerable<Order> orders = this.orderRepository.GetByDate(date);

            return Ok(orders);
        }
    }
}
