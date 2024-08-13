using System;

namespace BankApp
{
    class Program
    {
        static void Main(string[] args)
        {
            AccountHolder holder = new AccountHolder("Ahmad Qasem");
            BankAccount account = new BankAccount(200,1000,"123456789");

            account.BalanceChanged += holder.OnBalanceChanged;
            account.Deposit(holder, 100);
            account.Withdraw(holder, 50);
        }


    }
}
