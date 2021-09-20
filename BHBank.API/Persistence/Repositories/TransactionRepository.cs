using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BHBank.API.Domain.Models;
using BHBank.API.Domain.Repositories;
using BHBank.API.Persistence.Contexts;

namespace BHBank.API.Persistence.Repositories
{
    public class TransactionRepository : BaseRepository, ITransactionRepository
    {
        public TransactionRepository(AppDbContext context) : base(context)
        {            
        }
        public async Task SaveAsync(Transaction transaction)
        {
            await _context.Transactions.AddAsync(transaction);
        }
    }
}