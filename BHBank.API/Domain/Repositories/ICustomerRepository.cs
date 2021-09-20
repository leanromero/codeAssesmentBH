using System.Collections.Generic;
using System.Threading.Tasks;
using BHBank.API.Domain.Models;

namespace BHBank.API.Domain.Repositories
{
    public interface ICustomerRepository
    {
         Task<IEnumerable<Customer>> ListAsync();
         Task<Customer> GetByIdAsync(int id);
    }
}