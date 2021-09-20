using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using BHBank.API.Domain.Models;
using BHBank.API.Domain.Services;
using BHBank.API.Resources;


namespace BHBank.API.Controllers
{
    [Route("/api/[controller]")]
    public class AccountsController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly ICustomerService _customerService;
        private readonly ITransactionService _transactionService;
        
        public AccountsController(IAccountService accountService, ICustomerService customerService, ITransactionService transactionService)
        {
            _accountService = accountService;
            _customerService = customerService;
            _transactionService = transactionService;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] AccountResource resource)
        {
            //Only create accounts if the customer exists
            Customer customer = await _customerService.GetByIdAsync(resource.customerID);
            if (customer is null)
                return BadRequest("Customer does not exist");
            //create a new account
            Account account = new Account();
            try
            {
                
                account.Customer = customer;
                //TODO: Type can be an Enum or handled by inheritance
                account.Type = "Current";
                // Creating the transaction
                if (resource.initialCredit != 0)
                {
                    Transaction transaction = new Transaction();
                    transaction.Account = account;
                    transaction.Value = resource.initialCredit;
                    await _transactionService.SaveAsync(transaction);
                }                
                
                await _accountService.SaveAsync(account); 
   
                await _accountService.CompleteAsync();

            }
            catch (System.Exception)
            {
                //TODO: Error handling
                return BadRequest("Error on saving account");
            }
            
            return Ok(account.Id);

        }
    }
}