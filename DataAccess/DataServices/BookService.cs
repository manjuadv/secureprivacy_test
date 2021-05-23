using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using Task1.Core.Models;

namespace DataAccess.DataServices
{
    public class BookService
    {
        private readonly IMongoCollection<Book> _books;

        public BookService(IBookstoreDatabaseSettings settings)
        {

            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _books = database.GetCollection<Book>(settings.BooksCollectionName);
        }

        /*public List<Book> Get() =>
            _books.Find(book => true).ToList();
        */
        public async Task<IEnumerable<Book>> Get()
        {
            var r = await _books.FindAsync(filter => true);

            return r.ToList();
        }
        /*public Book Get(string id) =>
            _books.Find<Book>(book => book.Id == id).FirstOrDefault();
        */
        public async Task<Book> Get(string id)
        {
            var r = await _books.FindAsync(book => book.Id == id);
            Book book = r.FirstOrDefault();

            return book;
        }
        public async Task<Book> Insert(Book book)
        {
            await _books.InsertOneAsync(book);

            return book;
        }

        /*public void Update(string id, Book bookIn) =>
            _books.ReplaceOne(book => book.Id == id, bookIn);
        */
        public async Task<bool> Update(string id, Book bookIn)
        {
            var result = await _books.ReplaceOneAsync(book => book.Id == id, bookIn);

            return result.IsAcknowledged;
        }

        /*public void Remove(string id) =>
            _books.DeleteOne(book => book.Id == id);*/

        public async Task Remove(string id)
        {
            var result = await _books.DeleteOneAsync(book => book.Id == id);
        }
    }
}
