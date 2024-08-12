using System;
namespace BankApp
{
    public class AccountHolder
    {
        public string? Name { get; set; }
        public decimal Balance { get; set; }
        public AccountHolder(string Name, decimal Balance)
        {
            this.Name = Name;
            this.Balance = Balance;
        }
    }
}