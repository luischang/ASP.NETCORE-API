using AutoMapper;
using M5_NETCORE.CORE.DTOs;
using M5_NETCORE.CORE.Entities;
using M5_NETCORE.CORE.Exceptions;
using M5_NETCORE.CORE.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace M5_NETCORE.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        //private readonly ICustomerRepository _customerRepository;
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;
        public CustomerController(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Customer()
        {
            //CustomerRepository _customerRepository = new CustomerRepository();
            //CustomerRepositoryDapper customerRepositoryDapper = new CustomerRepositoryDapper();
            var customers = await _customerService.GetCustomer();
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

        [HttpGet("{id}")]
        public async Task<IActionResult> CustomerById(int id)
        {
            var customer = await _customerService.GetCustomerById(id);
            var customerDTO = _mapper.Map<CustomerDTO>(customer);
            return Ok(customerDTO);
        }



        [HttpPost]
        public async Task<IActionResult> PostCustomer(CustomerDTO customerDTO)
        {
            var customer = _mapper.Map<Customer>(customerDTO);
            await _customerService.InsertCustomer(customer);
            return Ok(customer);
        }
        [HttpPut]
        public async Task<IActionResult> PutCustomer(Customer customer)
        {
            await _customerService.UpdateCustomer(customer);
            return Ok(customer);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var result = await _customerService.DeleteCustomer(id);
            return Ok(result);
        }

    }
}
