using System.Collections.Generic;
using System.Threading.Tasks;
using BHBank.API.Domain.Models;
using BHBank.API.Domain.Services;
using BHBank.API.Domain.Repositories;

namespace BHBank.API.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            this._customerRepository = customerRepository;
        }

        public async Task<IEnumerable<Customer>> ListAsync()
        { 
            return await _customerRepository.ListAsync();
        }

        public async Task<Customer> GetByIdAsync(int id)
        {
            return await _customerRepository.GetByIdAsync(id);            
        }
    }
}