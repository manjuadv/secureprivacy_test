using DataAccess.DataServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Task1.Core.DBRepository;
using Task1.Core.Models;

namespace DataAccess.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly BookService _bookService;

        public BookRepository(BookService bookService)
        {
            _bookService = bookService;
        }
        public void Add(Book book)
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

        public IEnumerable GetProducts()
        {
            return _bookService.Get();
        }

        public void Remove(string Id)
        {
            _bookService.Remove(Id);
        }
    }
}
