using System;
namespace BankApp
{
    public class AccountHolder
    {
        private string? name;


        public string? Name
        {
            get { return name; }
            set { name = value; }
        }



        public AccountHolder(string Name)
        {
            this.Name = Name;

        }
        public void OnBalanceChanged(string transactionName, BankAccount account, decimal oldBalance)
        {
            Console.WriteLine($" Hi {Name},\n {transactionName} transaction is successful,\n  Old Balance: {oldBalance}, New Balance: {account.Balance}");
        }
    }
}