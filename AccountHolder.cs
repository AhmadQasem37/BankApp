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
        public void OnBalanceChanged(string transactionName, AccountHolder holder, decimal oldBalance)
        {
            Console.WriteLine($" Hi {holder.Name},\n {transactionName} transaction is successful,\n  Old Balance: {oldBalance}, New Balance: {holder.Balance}");
        }
    }
}