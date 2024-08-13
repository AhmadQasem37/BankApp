using System;
namespace BankApp
{
    public class AccountHolder
    {
        private string? name;
        private decimal balance;

        public string? Name
        {
            get { return name; }
            set { name = value; }
        }

        public decimal Balance
        {
            get { return balance; }
            set { balance = value; }
        }

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