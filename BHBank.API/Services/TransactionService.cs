using System.Collections.Generic;
using System.Threading.Tasks;
using BHBank.API.Domain.Models;
using BHBank.API.Domain.Services;
using BHBank.API.Domain.Repositories;

namespace BHBank.API.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionService(ITransactionRepository transactionRepository)
        {
            this._transactionRepository = transactionRepository;
        }

        public async Task SaveAsync(Transaction transaction)
        {
            await _transactionRepository.SaveAsync(transaction);
        }

    }
}