using M5_NETCORE.CORE.Entities;
using M5_NETCORE.INFRASTRUCTURE.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using M5_NETCORE.CORE.Interfaces;

namespace M5_NETCORE.INFRASTRUCTURE.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly SalesContext _context;

        public CustomerRepository()
        {

        }

        public CustomerRepository(SalesContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Customer>> GetCustomer()
        {
            //using (var data = new SalesContext())
            //{
            //    var customers = await data.Customers.ToListAsync();
            //    return customers;
            //}        

            var customers = await _context.Customers.ToListAsync();
            return customers;
        }

        public async Task<Customer> GetCustomerById(int id)
        {
            //var customer = await _context.Customers.Where(x => x.Id == id).FirstOrDefaultAsync();
            var customer = await _context.Customers.FirstOrDefaultAsync(x => x.Id == id);
            return customer;
        }

        public async Task InsertCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateCustomer(Customer customer)
        {
            var currentCustomer = await GetCustomerById(customer.Id);
            currentCustomer.FirstName = customer.FirstName;
            currentCustomer.LastName = customer.LastName;
            currentCustomer.City = customer.City;
            currentCustomer.Country = customer.Country;
            currentCustomer.Phone = customer.Phone;

            int countRows = await _context.SaveChangesAsync();
            return (countRows > 0);
        }

        public async Task<bool> DeleteCustomer(int id)
        {
            var currentCustomer = await GetCustomerById(id);
            _context.Customers.Remove(currentCustomer);
            int countRows = await _context.SaveChangesAsync();
            return (countRows > 0);
        }


    }
}
