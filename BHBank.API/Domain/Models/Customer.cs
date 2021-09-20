using System.Collections.Generic;

namespace BHBank.API.Domain.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public IList<Account> Accounts { get; set; }
    }
}
