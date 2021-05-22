using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Task1.Core.Models;

namespace Task1.Core.Repositories
{
    public interface IBookRepository
    {
        void Add(Book book);
        void Edit(Book book);
        void Remove(string Id);
        IEnumerable GetProducts(); 
        Book FindById(string Id);
    }    
}
