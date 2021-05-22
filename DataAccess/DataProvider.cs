using DataAccess.DomainObjs;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace DataAccess
{
    public class DataProvider
    {
        public List<Product> GetData()
        {
            var client = new MongoClient();
            var db = client.GetDatabase("store");
            var col = db.GetCollection<Product>("product");

            var id = new ObjectId("60a7ca38373f78a305d83643");
            var prods = col.Find(r => r.Id == id).Limit(5).ToList<Product>();

            return prods;
        }

        public Product GetFirst()
        {
            var client = new MongoClient();
            var db = client.GetDatabase("store");
            var col = db.GetCollection<Product>("product");

            var id = new ObjectId("60a7ca38373f78a305d83643");
            var prod = col.Find(r => r.Id == id).FirstOrDefault();

            return prod;
        }
        public BsonDocument GetFirstBson()
        {
            var client = new MongoClient();
            var db = client.GetDatabase("store");
            var col = db.GetCollection<BsonDocument>("product");

            var id = new ObjectId("60a7ca38373f78a305d83643");
            var prod = col.Find(new BsonDocument()).FirstOrDefault();

            return prod;
        }

        public void InsertBson(BsonDocument doc)
        {
            var client = new MongoClient();
            var db = client.GetDatabase("store");
            var col = db.GetCollection<BsonDocument>("product");

            col.InsertOne(doc);
        }

        public void InsertBsonSer(Customer cus)
        {
            var client = new MongoClient();
            var db = client.GetDatabase("store");
            var col = db.GetCollection<Customer>("customer");

            col.InsertOne(cus);
        }
    }
}
