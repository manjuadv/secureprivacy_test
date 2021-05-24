using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Task1.StoreApi.Core.Models
{
    public class Order : ModelBase
    {
        public DateTime CreatedAt { get; set; }
        public string CustomerId { get; set; }
        public List<OrderItem> Items { get; set; }
    }
}
