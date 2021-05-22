using DataAccess;
using DataAccess.DomainObjs;
using MongoDB.Bson;
using System;

namespace Tester
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            DataProvider dp = new DataProvider();

            var prods = dp.GetData();

            foreach (var pro in prods)
            {
                Console.WriteLine(pro.name);
            }

            var prod = dp.GetFirst();

            Console.WriteLine(prod.name);

            var prodBsn = dp.GetFirstBson();
            Console.WriteLine(prodBsn);

            var ndoc = new BsonDocument
            {
                {"name" , "Butter " + DateTime.Now.Millisecond.ToString()},
                {"quantity" , "1414"}
            };

            dp.InsertBson(ndoc);

            dp.InsertBsonSer(new Customer { FirstName = "Nuwan", LastName="Kumara", Address="48, Gall Road, Rathmalana", CreatedAt = DateTime.Now });
        }
    }
}
