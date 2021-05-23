using DataAccess;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Task1.StoreApi.Core.Models;

namespace Task1.DataAccess.MongoDataServices
{
    public class OrderService
    {
        private readonly IMongoCollection<Order> _orderCollection;

        public OrderService(IStoreDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _orderCollection = database.GetCollection<Order>(settings.OrdersCollectionName);
        }
        public async Task<IEnumerable<Order>> Get()
        {
            var result = await _orderCollection.FindAsync(filter => true);

            return result.ToList();
        }
        public async Task<Order> Get(string id)
        {
            var result = await _orderCollection.FindAsync(order => order.Id == id);
            Order order = result.FirstOrDefault();

            return order;
        }
        public async Task Insert(Order order)
        {
            await _orderCollection.InsertOneAsync(order);
        }
        public async Task Update(string id, Order orderIn)
        {
            if (await IsDocumentAvailable(id))
            {
                var result = await _orderCollection.ReplaceOneAsync(order => order.Id == id, orderIn, new ReplaceOptions { IsUpsert = false });
                if (result.ModifiedCount > 0)
                {
                    // Do nothing, success
                }
                else
                {
                    throw new Exception("Order update failed");
                }
            }
            else
            {
                throw new InvalidOperationException("The order does not exist");
            }
        }
        public async Task Remove(string id)
        {
            if (await IsDocumentAvailable(id))
            {
                var result = await _orderCollection.DeleteOneAsync(order => order.Id == id);
            }
            else
            {
                throw new InvalidOperationException("The order does not exist");
            }
        }
        private async Task<bool> IsDocumentAvailable(string id)
        {
            // Aggregate is used here to get the count with given id
            // Since aggregate is used, count is calculated in database level without loading the documents to memory
            
            var countResult = await _orderCollection.Aggregate<Order>()
            .Match(order => order.Id == id)
            .Limit(1)
            .Count()
            .FirstOrDefaultAsync();

            if (countResult != null && countResult.Count > 0)
                return true;
            return false;
        }
    }
}
