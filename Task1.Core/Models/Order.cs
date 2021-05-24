using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Task1.StoreApi.Core.Models
{
    public class Order : ModelBase
    {
        /*[BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }*/
        public DateTime CreatedAt { get; set; }
        public string CustomerId { get; set; }
        public List<OrderItem> Items { get; set; }
    }
}
