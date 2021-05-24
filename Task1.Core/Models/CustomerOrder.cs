using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Task1.StoreApi.Core.Models
{
    public class CustomerOrder
    {
        public DateTime CreatedAt { get; set; }
        public string CustomerId { get; set; }
        public List<OrderItem> Items { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }
        [BsonElement("Phone")]
        public string PhoneNumer { get; set; }
        public CustomerOrder(Order order, Customer customer)
        {
            CreatedAt = order.CreatedAt;
            CustomerId = order.CustomerId;
            Items = order.Items;
            FirstName = customer.FirstName;
            LastName = customer.LastName;
            Email = customer.Email;
            PhoneNumer = customer.PhoneNumer;
        }
    }
}
