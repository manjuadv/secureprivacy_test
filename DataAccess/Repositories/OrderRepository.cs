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
        private readonly CustomerService _customerService;
        public OrderRepository(OrderService orderService, CustomerService customerService) : base(orderService)
        {
            _customerService = customerService;
        }

        public async Task<CustomerOrder> GetCustomerOrder(string orderId)
        {          
            var order = await base.Get(orderId);
            var customer = await _customerService.Get(order.CustomerId);

            return new CustomerOrder(order, customer);
        }
        public async Task<IEnumerable<Order>> GetCustomerOrders(string customerId)
        {
            OrderService orderService = (OrderService)base.MongoDbService;
            return await orderService.GetCustomerOrders(customerId);
        }
    }
}
