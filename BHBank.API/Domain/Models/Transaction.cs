using System.Collections.Generic;

namespace BHBank.API.Domain.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public double Value { get; set; }

        public int AccountId {get; set;}
        public Account Account { get; set; } 
    }
}