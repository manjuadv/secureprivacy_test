using DataAccess.DataServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Task1.Core.DBRepository;
using Task1.Core.Models;

namespace DataAccess.Repositories
{
    public class BookRepository : IBookRepository
    {
        private BookService _bookService;

        public BookRepository(BookService bookService)
        {
            _bookService = bookService;
        }

        public async Task<Book> Create(Book book)
        {
            Book insertedBook = await _bookService.Insert(book);

            return insertedBook;
        }

        public async Task Delete(string Id)
        {
            await _bookService.Remove(Id);
        }

        public async Task<IEnumerable<Book>> Get()
        {
            IEnumerable<Book> books = await _bookService.Get();

            return books;
        }

        public async Task<Book> Get(string Id)
        {
            Book book = await _bookService.Get(Id);

            return book;
        }

        public async Task<bool> Update(string Id, Book book)
        {
            return await _bookService.Update(Id, book);
        }
        /*public void Add(Book book)
{
   _bookService.Create(book);
}

public void Edit(string Id, Book book)
{
   _bookService.Update(Id, book);
}

public Book FindById(string Id)
{
   return _bookService.Get(Id);
}

public List<Book> Get()
{
   return _bookService.Get();
}

public void Remove(string Id)
{
   _bookService.Remove(Id);
}*/
    }
}
