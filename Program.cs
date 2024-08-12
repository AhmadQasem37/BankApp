using System;

namespace BankApp
{
    class Program
    {
        static void Main(string[] args)
        {
            AccountHolder holder = new AccountHolder("John Doe", 150);
            BankAccount account = new BankAccount(200);

            account.BalanceChanged += holder.OnBalanceChanged;
            account.Deposit(holder, 100);
            account.Withdraw(holder, 50);
        }


    }
}
