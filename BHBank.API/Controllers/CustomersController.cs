using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using BHBank.API.Domain.Models;
using BHBank.API.Domain.Services;


namespace BHBank.API.Controllers
{
    [Route("/api/[controller]")]
    public class CustomersController : Controller
    {
        private readonly ICustomerService _customerService;
        
        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;   
        }

        [HttpGet]
        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            var customers = await _customerService.ListAsync();
            return customers;
        }

    }
}