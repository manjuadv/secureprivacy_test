using DataAccess;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using Task1.StoreApi.Core.Models;

namespace Task1.DataAccess.MongoDataServices
{
    public class ProductService : MongoServiceBase<Product>
    {
        public ProductService(IStoreDatabaseSettings settings) : base(settings, settings.ProductsCollectionName)
        {

        }
    }
}
