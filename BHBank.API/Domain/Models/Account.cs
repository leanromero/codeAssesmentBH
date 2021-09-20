using System.Collections.Generic;
using System.Linq;

namespace BHBank.API.Domain.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public IList<Transaction> Transactions { get; set; }
        
        //TODO: Assumption! Balance belongs to the account. (An user can have multiple accunts with different balances each.)
        public double Balance {
            get { return Transactions.Sum(t => t.Value); }
        }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}