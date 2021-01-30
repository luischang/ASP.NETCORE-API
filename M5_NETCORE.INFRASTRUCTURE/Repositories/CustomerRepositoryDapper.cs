using M5_NETCORE.CORE.Entities;
using M5_NETCORE.CORE.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace M5_NETCORE.INFRASTRUCTURE.Repositories
{
    public class CustomerRepositoryDapper : ICustomerRepository
    {
        public Task<bool> DeleteCustomer(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Customer>> GetCustomer()
        {
            throw new NotImplementedException();
        }

        public Task<Customer> GetCustomerById(int id)
        {
            throw new NotImplementedException();
        }

        public Task InsertCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
