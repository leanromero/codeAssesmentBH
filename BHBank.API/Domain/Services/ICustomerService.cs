using System.Collections.Generic;
using System.Threading.Tasks;
using BHBank.API.Domain.Models;

namespace BHBank.API.Domain.Services
{
    public interface ICustomerService
    {
         Task<IEnumerable<Customer>> ListAsync();
         Task<Customer> GetByIdAsync(int id);
    }
}