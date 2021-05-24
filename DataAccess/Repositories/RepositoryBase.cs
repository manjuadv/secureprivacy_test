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
        private readonly MongoServiceBase<T> _productService;

        public RepositoryBase(MongoServiceBase<T> productService)
        {
            _productService = productService;
        }
        public async Task Create(T product)
        {
            await _productService.Insert(product);
        }

        public async Task Delete(string id)
        {
            await _productService.Remove(id);
        }

        public async Task<IEnumerable<T>> Get()
        {
            return await _productService.Get();
        }

        public async Task<T> Get(string id)
        {
            return await _productService.Get(id);
        }

        public async Task Update(string id, T product)
        {
            await _productService.Update(id, product);
        }
    }
}
