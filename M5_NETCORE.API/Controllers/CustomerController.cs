using AutoMapper;
using M5_NETCORE.CORE.DTOs;
using M5_NETCORE.CORE.Entities;
using M5_NETCORE.CORE.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace M5_NETCORE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        public CustomerController(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Customer()
        {
            //CustomerRepository _customerRepository = new CustomerRepository();
            //CustomerRepositoryDapper customerRepositoryDapper = new CustomerRepositoryDapper();
            var customers = await _customerRepository.GetCustomer();
            //var customersDTO = customers.Select(x => new CustomerDTO
            //{
            //    Id = x.Id,
            //    FirstName = x.FirstName,
            //    LastName = x.LastName,
            //    City = x.City,
            //    Country = x.Country
            //});
            var customersDTO = _mapper.Map<IEnumerable<CustomerDTO>>(customers);
            return Ok(customersDTO);
        }
        [HttpPost]
        public async Task<IActionResult> PostCustomer(CustomerDTO customerDTO)
        {
            var customer = _mapper.Map<Customer>(customerDTO);
            await _customerRepository.InsertCustomer(customer);
            return Ok(customer);
        }
        [HttpPut]
        public async Task<IActionResult> PutCustomer(Customer customer)
        {
            await _customerRepository.UpdateCustomer(customer);
            return Ok(customer);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var result = await _customerRepository.DeleteCustomer(id);
            return Ok(result);
        }

    }
}
