using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Task1.StoreApi.Core.Models
{
    public class OrderItem
    {
        public string ProductName { get; set; }
        public string ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
