using System;
using System.Text;
namespace BankApp
{
    public delegate void BalanceChangedHandler(string transactionName, BankAccount account, decimal oldBalance);

    public class BankAccount
    {

        private readonly decimal threshold = 200m;
        private decimal balance;
        private readonly string accountNumber;


        public BankAccount(decimal threshold, decimal balance, string accountNumber)
        {
            this.threshold = threshold;
            this.accountNumber = accountNumber;
            this.balance = balance;
        }

        public event BalanceChangedHandler? BalanceChanged;

        public decimal Balance
        {
            get { return balance; }
            set { balance = value; }
        }
        public void Deposit(AccountHolder holderInfo, decimal amount)
        {

            var oldBalance = Balance;
            Balance += amount;
            BalanceChanged?.Invoke("Deposit", this, oldBalance);

        }

        public void Withdraw(AccountHolder holderInfo, decimal amount)
        {

            var oldBalance = Balance;
            if (Balance - amount < threshold)
            {
                Console.WriteLine($"Hi {holderInfo.Name}, Transaction canceled: Balance would fall below the threshold");
                return;
            }
            this.balance -= amount;
            BalanceChanged?.Invoke("Withdraw", this, oldBalance);
        }

    }
}