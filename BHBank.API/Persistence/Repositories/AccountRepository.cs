using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BHBank.API.Domain.Models;
using BHBank.API.Domain.Repositories;
using BHBank.API.Persistence.Contexts;

namespace BHBank.API.Persistence.Repositories
{
    public class AccountRepository : BaseRepository, IAccountRepository
    {
        public AccountRepository(AppDbContext context) : base(context)
        {            
        }
        public async Task SaveAsync(Account account)
        {
            await _context.Accounts.AddAsync(account);
        }
    }
}