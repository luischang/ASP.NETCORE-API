using M5_NETCORE.CORE.Entities;
using M5_NETCORE.CORE.Exceptions;
using M5_NETCORE.CORE.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace M5_NETCORE.CORE.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<bool> DeleteCustomer(int id)
        {
            bool exito = await _customerRepository.DeleteCustomer(id);
            return exito;
        }

        public async Task<IEnumerable<Customer>> GetCustomer()
        {
            return await _customerRepository.GetCustomer();
        }

        public async Task<Customer> GetCustomerById(int customerId)
        {
            var customer =  await _customerRepository.GetCustomerById(customerId);
            if (customer == null)
                throw new GeneralException("El cliente no existe");

            return customer;
        }

        public async Task InsertCustomer(Customer customer)
        {
            await _customerRepository.InsertCustomer(customer);
        }

        public async Task<bool> UpdateCustomer(Customer customer)
        {
            bool exito = await _customerRepository.UpdateCustomer(customer);
            return exito;
        }

    }
}
