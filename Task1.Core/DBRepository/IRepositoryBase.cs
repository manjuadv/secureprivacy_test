using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Task1.StoreApi.Core.Models;

namespace Task1.StoreApi.Core.DBRepository
{
    public interface IRepositoryBase<T>
    {
        Task<IEnumerable<T>> Get();
        Task<T> Get(string Id);
        Task Create(T element);
        Task Update(string Id, T element);
        Task Delete(string Id);
    }    
}
