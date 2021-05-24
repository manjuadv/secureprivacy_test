using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task1.Core.DBRepository;
using Task1.StoreApi.Core.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Task1.OrderApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrdersController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<IEnumerable<Order>> Get()
        {
            return await _orderRepository.Get();
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerOrder>> Get(string id)
        {
            CustomerOrder order = await _orderRepository.GetCustomerOrder(id);
            //IEnumerable<Order> ord = await _orderRepository.GetCustomerOrders(order.CustomerId);

            if (order == null)
                return NotFound();
            return order;
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Order order)
        {
            await _orderRepository.Create(order);
            return Ok();
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(string id, [FromBody] Order order)
        {
            await _orderRepository.Update(id, order);

            return NoContent();
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            await _orderRepository.Delete(id);
            return NoContent();
        }
    }
}
