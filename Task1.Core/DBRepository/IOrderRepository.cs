using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Task1.StoreApi.Core.DBRepository;
using Task1.StoreApi.Core.Models;

namespace Task1.Core.DBRepository
{
    public interface IOrderRepository : IRepositoryBase<Order>
    {
        Task<CustomerOrder> GetCustomerOrder(string orderId);
        Task<IEnumerable<Order>> GetCustomerOrders(string customerId);
    }
    /*public interface IOrderRepository
    {
        Task<IEnumerable<Order>> Get();
        Task<Order> Get(string Id);
        Task Create(Order order);
        Task Update(string Id, Order order);
        Task Delete(string Id);
    }*/
}
