using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Task1.StoreApi.Core.Models
{
    public class Customer
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }
        [BsonElement("Phone")]
        public string PhoneNumer { get; set; }
    }
}
