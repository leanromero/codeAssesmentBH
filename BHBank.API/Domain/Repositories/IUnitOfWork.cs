using System.Threading.Tasks;

namespace BHBank.API.Domain.Repositories
{
    public interface IUnitOfWork
    {
         Task CompleteAsync();
    }
}