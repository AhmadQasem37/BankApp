using System;

namespace BankApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            List<BankAccount> accounts = new List<BankAccount>();
            List<AccountHolder> holders = new List<AccountHolder>();
            string[] names = { "ahmad", "ali", "mohammed", "yamen", "reem", "lana" };

            int length = random.Next(1, 5);
            for (int i = 0; i < length; i++)
            {
                accounts.Add(new BankAccount(random.Next(100, 501), random.Next(10000), random.Next(10000000, 100000000).ToString()));
                holders.Add(new AccountHolder(names[random.Next(names.Length)]));
                accounts[i].BalanceChanged += holders[i].OnBalanceChanged;
            }

            for (int i = 0; i < length; i++)
            {


                for (int j = 0; j < 2; j++)
                {
                    int operation = random.Next(1, 3);
                    if (operation == 1)
                    {
                        accounts[i].Deposit(holders[i], random.Next(100, 501));
                    }
                    else
                    {
                        accounts[i].Withdraw(holders[i], random.Next(100, 501));
                    }
                }
                Console.WriteLine("Transaction History:");
                foreach (var transaction in accounts[i].TransactionHistory)
                {
                    Console.WriteLine(transaction);
                }

                Console.WriteLine("\n--------------------------------------------------------------\n");


            }
        }


    }
}
