using System.Collections.Generic;
using System.Threading.Tasks;
using BHBank.API.Domain.Models;

namespace BHBank.API.Domain.Repositories
{
    public interface IAccountRepository
    {
         Task SaveAsync(Account account);
    }
}