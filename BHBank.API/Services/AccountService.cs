using System.Collections.Generic;
using System.Threading.Tasks;
using BHBank.API.Domain.Models;
using BHBank.API.Domain.Services;
using BHBank.API.Domain.Repositories;

namespace BHBank.API.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AccountService(IAccountRepository accountRepository, IUnitOfWork unitOfWork)
        {
            _accountRepository = accountRepository;
            _unitOfWork = unitOfWork;

        }

        public async Task SaveAsync(Account account)
        {
            await _accountRepository.SaveAsync(account);            
        }

        //TODO: only this service will commit the changes into the database (Based on the exercise)
        public async Task CompleteAsync()
        {
            await _unitOfWork.CompleteAsync();
        }

    }
}