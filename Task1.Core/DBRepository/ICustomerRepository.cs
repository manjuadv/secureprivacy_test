using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Task1.StoreApi.Core.Models;

namespace Task1.Core.DBRepository
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> Get();
        Task<Customer> Get(string Id);
        Task Create(Customer customer);
        Task Update(string Id, Customer customer);
        Task Delete(string Id);
    }    
}
