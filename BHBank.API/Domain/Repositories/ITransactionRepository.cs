using System.Collections.Generic;
using System.Threading.Tasks;
using BHBank.API.Domain.Models;

namespace BHBank.API.Domain.Repositories
{
    public interface ITransactionRepository
    {
         Task SaveAsync(Transaction transaction);
    }
}