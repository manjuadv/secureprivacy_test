using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Task1.Core.Models;

namespace Task1.Core.DBRepository
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> Get();
        Task<Book> Get(string Id);
        Task<Book> Create(Book book);
        Task<bool> Update(string Id, Book book);
        Task Delete(string Id);

        /*void Add(Book book);
        void Edit(string Id, Book book);
        void Remove(string Id);
        List<Book> Get(); 
        Book FindById(string Id);*/
    }    
}
