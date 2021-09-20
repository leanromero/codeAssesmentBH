using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BHBank.API.Domain.Models;
using BHBank.API.Domain.Repositories;
using BHBank.API.Persistence.Contexts;

namespace BHBank.API.Persistence.Repositories
{
    public class CustomerRepository : BaseRepository, ICustomerRepository
    {
        public CustomerRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Customer>> ListAsync()
        {
            return await _context.Customers.Include(c => c.Accounts).ThenInclude(a => a.Transactions).ToListAsync();
        }
        
        public async Task<Customer> GetByIdAsync(int id)
        {
            return await _context.Customers.FindAsync(id);
        }
    }
}