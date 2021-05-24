using FakeItEasy;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Task1.Core.DBRepository;
using Task1.DataAccess.MongoDataServices;
using Task1.DataAccess.Repositories;
using Task1.OrderApi.Controllers;
using Task1.StoreApi.Core.Models;
using Xunit;

namespace StoreApiTest
{
    public class OrderControllerTest
    {
        [Fact]
        public async Task Get_Orders_Returns_List()
        {
            // Arrange
            int count = 5;
            var mockRepository = A.Fake<IOrderRepository>();
            var mockOrders = A.CollectionOfDummy<Order>(count);            
            A.CallTo(() => mockRepository.Get()).Returns(mockOrders);
            var controller = new OrdersController(mockRepository);

            // Act
            IEnumerable<Order> orders = await controller.Get();

            // Assert
            Assert.True(orders!=null && orders.GetEnumerator().MoveNext());
        }
        [Fact]
        public async Task Get_Order_Returns_Order()
        {
            // Arrange
            string id = "string_value";            
            var mockOrder = A.Dummy<CustomerOrder>();
            var mockRepository = A.Fake<IOrderRepository>();
            A.CallTo(() => mockRepository.GetCustomerOrder(id)).Returns(mockOrder);
            var controller = new OrdersController(mockRepository);

            // Act
            var order = await controller.Get(id);

            // Assert
            Assert.True(order.Value != null);
        }
        [Fact]
        public async Task Add_Order_Success_Return_OK()
        {
            // Arrange
            Order order = A.Dummy<Order>();
            order.Id = "order_id";
            List<Order> ordersCollection = new List<Order>();
            var mockRepository = A.Fake<IOrderRepository>();
            A.CallTo(() => mockRepository.Create(order)).Invokes(()=> ordersCollection.Add(order));
            var controller = new OrdersController(mockRepository);

            // Act
            var result = await controller.Post(order);
            // Assert
            Assert.Equal(order.Id , ordersCollection[0].Id);
            
        }       
    }
}
