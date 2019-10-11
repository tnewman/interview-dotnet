using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace GroceryStoreAPI.Order
{
    public interface IOrderController
    {
        IEnumerable<Order> List();

        ActionResult<Order> Get(int id);

        IEnumerable<Order> GetByCustomer(int customerId);

        IEnumerable<Order> GetByDate(DateTime date);
    }

    [Route("api/order")]
    [ApiController]
    public class OrderController : ControllerBase, IOrderController
    {
        IOrderRepository orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        [HttpGet]
        public IEnumerable<Order> List()
        {
            return this.orderRepository.List();
        }

        [HttpGet("{id}")]
        public ActionResult<Order> Get(int id)
        {
            Order order = this.orderRepository.Get(id);

            if (order == null)
            {
                return NotFound();
            }

            return order;
        }

        [HttpGet("customer/{customerId}")]
        public IEnumerable<Order> GetByCustomer(int customerId)
        {
            IEnumerable<Order> orders = this.orderRepository.GetByCustomer(customerId);

            return orders;
        }

        [HttpGet("date/{date}")]
        public IEnumerable<Order> GetByDate(DateTime date)
        {
            IEnumerable<Order> orders = this.orderRepository.GetByDate(date);

            return orders;
        }
    }
}
