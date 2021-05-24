using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Task1.Core.DBRepository;
using Task1.DataAccess.MongoDataServices;
using Task1.StoreApi.Core.Models;

namespace Task1.DataAccess.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerService _customerService;

        public CustomerRepository(CustomerService customerService)
        {
            _customerService = customerService;
        }
        public async Task Create(Customer customer)
        {
            await _customerService.Insert(customer);
        }

        public async Task Delete(string id)
        {
            await _customerService.Remove(id);
        }

        public async Task<IEnumerable<Customer>> Get()
        {
            return await _customerService.Get();
        }

        public async Task<Customer> Get(string id)
        {
            return await _customerService.Get(id);
        }

        public async Task Update(string id, Customer customer)
        {
            await _customerService.Update(id, customer);
        }
    }
}
