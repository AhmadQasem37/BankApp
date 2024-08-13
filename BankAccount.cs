using System;
using System.Text;
namespace BankApp
{
    public delegate void BalanceChangedHandler(string transactionName, AccountHolder holder, decimal oldBalance);

    public class BankAccount
    {
    
        private decimal threshold = 200m;

        public BankAccount(decimal threshold)
        {
            this.threshold = threshold;
        }

        public event BalanceChangedHandler BalanceChanged;

        public void Deposit(AccountHolder holder, decimal amount)
        {

            var oldBalance = holder.Balance;
            holder.Balance += amount;
            BalanceChanged?.Invoke("Deposit", holder, oldBalance);

        }

        public void Withdraw(AccountHolder holder, decimal amount)
        {

            var oldBalance = holder.Balance;
            if (holder.Balance - amount < threshold)
            {
                Console.WriteLine($"Hi {holder.Name}, Transaction canceled: Balance would fall below the threshold");
                return;
            }
            holder.Balance -= amount;
            BalanceChanged?.Invoke("Withdraw", holder, oldBalance);
        }

    }
}