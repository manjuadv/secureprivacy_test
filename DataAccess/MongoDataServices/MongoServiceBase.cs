using DataAccess;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Task1.StoreApi.Core.Models;

namespace Task1.DataAccess.MongoDataServices
{
    public class MongoServiceBase<T> where T : ModelBase
    {
        private readonly IMongoCollection<T> _documentCollection;

        public MongoServiceBase(IStoreDatabaseSettings settings, string collectionName)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _documentCollection = database.GetCollection<T>(collectionName);
        }
        public async Task<IEnumerable<T>> Get()
        {
            var result = await _documentCollection.FindAsync(filter => true);

            return result.ToList();
        }
        public async Task<T> Get(string id)
        {
            var result = await _documentCollection.FindAsync(element => element.Id == id);
            T element = result.FirstOrDefault();

            return element;
        }
        public async Task Insert(T element)
        {
            await _documentCollection.InsertOneAsync(element);
        }
        public async Task Update(string id, T elementIn)
        {
            if (await GetDocumentCount(id) > 0)
            {
                var result = await _documentCollection.ReplaceOneAsync(element => element.Id == id, elementIn, new ReplaceOptions { IsUpsert = false });
                if (result.ModifiedCount > 0)
                {
                    // Do nothing, success
                }
                else
                {
                    throw new Exception("Element update failed");
                }
            }
            else
            {
                throw new InvalidOperationException("The element does not exist");
            }
        }
        public async Task Remove(string id)
        {
            if (await GetDocumentCount(id) > 0)
            {
                var result = await _documentCollection.DeleteOneAsync(element => element.Id == id);
            }
            else
            {
                throw new InvalidOperationException("The element does not exist");
            }
        }
        protected async Task<long> GetDocumentCount(string id)
        {
            // Aggregate is used here to get the count with given id
            // Since aggregate is used, count is calculated in database level without loading the documents to memory

            var countResult = await _documentCollection.Aggregate<T>()
            .Match(element => element.Id == id)
            .Limit(1)
            .Count()
            .FirstOrDefaultAsync();

            if (countResult == null)
                return 0;
            else
                return countResult.Count;
        }

        protected IMongoCollection<T> DocumentCollection
        {
            get
            {
                return _documentCollection;
            }
        }

    }
}
