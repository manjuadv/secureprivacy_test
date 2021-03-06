using DataAccess;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Task1.StoreApi.Core.Models;

namespace Task1.DataAccess.MongoDataServices
{
    public class OrderService : MongoServiceBase<Order>
    {
        public OrderService(IStoreDatabaseSettings settings) : base(settings, settings.OrdersCollectionName)
        {

        }

        public async Task<IEnumerable<Order>> GetCustomerOrders(string customerId)
        {
            var result = await base.DocumentCollection.Aggregate<Order>()
            .Match(element => element.CustomerId == customerId)
            .SortByDescending(r=>r.CreatedAt)
            .ToListAsync();

            return result;
        }
        
    }
}
