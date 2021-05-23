using DataAccess;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Task1.StoreApi.Core.Models;

namespace Task1.DataAccess.MongoDataServices
{
    public class CustomerService
    {
        private readonly IMongoCollection<Customer> _customerCollection;

        public CustomerService(IStoreDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _customerCollection = database.GetCollection<Customer>(settings.CustomersCollectionName);
        }
        public async Task<IEnumerable<Customer>> Get()
        {
            var result = await _customerCollection.FindAsync(filter => true);

            return result.ToList();
        }
        public async Task<Customer> Get(string id)
        {
            var result = await _customerCollection.FindAsync(customer => customer.Id == id);
            Customer customer = result.FirstOrDefault();

            return customer;
        }
        public async Task Insert(Customer customer)
        {
            await _customerCollection.InsertOneAsync(customer);
        }
        public async Task Update(string id, Customer customerIn)
        {
            if (await IsDocumentAvailable(id))
            {
                var result = await _customerCollection.ReplaceOneAsync(customer => customer.Id == id, customerIn, new ReplaceOptions { IsUpsert = false });
                if (result.ModifiedCount > 0)
                {
                    // Do nothing, success
                }
                else
                {
                    throw new Exception("Customer update failed");
                }
            }
            else
            {
                throw new InvalidOperationException("The customer does not exist");
            }
        }
        public async Task Remove(string id)
        {
            if (await IsDocumentAvailable(id))
            {
                var result = await _customerCollection.DeleteOneAsync(Customer => Customer.Id == id);
            }
            else
            {
                throw new InvalidOperationException("The customer does not exist");
            }
        }
        private async Task<bool> IsDocumentAvailable(string id)
        {
            // Aggregate is used here to get the count with given id
            // Since aggregate is used, count is calculated in database level without loading the documents to memory
            
            var countResult = await _customerCollection.Aggregate<Customer>()
            .Match(customer => customer.Id == id)
            .Limit(1)
            .Count()
            .FirstOrDefaultAsync();

            if (countResult != null && countResult.Count > 0)
                return true;
            return false;
        }
    }
}
