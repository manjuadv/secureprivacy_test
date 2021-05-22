using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.DomainObjs
{
    public class Product 
    {
        public ObjectId Id { get; set; }
        public string name { get; set; }
        public string quantity { get; set; }
    }
}
