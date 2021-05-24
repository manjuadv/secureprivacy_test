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
        public OrderRepository(OrderService orderService) : base(orderService)
        {

        }
    }
}
