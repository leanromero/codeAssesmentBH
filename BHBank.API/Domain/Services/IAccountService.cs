using System.Collections.Generic;
using System.Threading.Tasks;
using BHBank.API.Domain.Models;

namespace BHBank.API.Domain.Services
{
    public interface IAccountService
    {
         Task SaveAsync(Account account);
         Task CompleteAsync();
    }
}