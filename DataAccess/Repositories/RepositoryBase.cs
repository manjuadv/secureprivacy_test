using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Task1.DataAccess.MongoDataServices;
using Task1.StoreApi.Core.Models;

namespace Task1.DataAccess.Repositories
{
    public class RepositoryBase<T> where T : ModelBase
    {
        private readonly MongoServiceBase<T> _mongoDbService;

        public RepositoryBase(MongoServiceBase<T> productService)
        {
            _mongoDbService = productService;
        }
        public virtual async Task Create(T product)
        {
            await _mongoDbService.Insert(product);
        }

        public virtual async Task Delete(string id)
        {
            await _mongoDbService.Remove(id);
        }

        public virtual async Task<IEnumerable<T>> Get()
        {
            return await _mongoDbService.Get();
        }

        public virtual async Task<T> Get(string id)
        {
            return await _mongoDbService.Get(id);
        }

        public virtual async Task Update(string id, T product)
        {
            await _mongoDbService.Update(id, product);
        }

        public MongoServiceBase<T> MongoDbService
        {
            get
            {
                return _mongoDbService;
            }
        }
    }
}
