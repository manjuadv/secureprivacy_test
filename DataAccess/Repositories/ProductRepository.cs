using System;
using System.Collections.Generic;
using System.Text;
using Task1.DataAccess.MongoDataServices;
using Task1.StoreApi.Core.DBRepository;
using Task1.StoreApi.Core.Models;

namespace Task1.DataAccess.Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(ProductService productService) : base(productService)
        {
            
        }
    }
}
