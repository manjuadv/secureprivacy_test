using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Task1.Core.DBRepository;
using Task1.DataAccess.MongoDataServices;
using Task1.StoreApi.Core.Models;

namespace Task1.DataAccess.Repositories
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(OrderService orderService) : base(orderService)
        {

        }
    }
    /*public class OrderRepository : IOrderRepository
    {
        private readonly OrderService _orderService;

        public OrderRepository(OrderService orderService)
        {
            _orderService = orderService;
        }
        public async Task Create(Order order)
        {
            await _orderService.Insert(order);
        }

        public async Task Delete(string id)
        {
            await _orderService.Remove(id);
        }

        public async Task<IEnumerable<Order>> Get()
        {
            return await _orderService.Get();
        }

        public async Task<Order> Get(string id)
        {
            return await _orderService.Get(id);
        }

        public async Task Update(string id, Order order)
        {
            await _orderService.Update(id, order);
        }
    }*/
}
