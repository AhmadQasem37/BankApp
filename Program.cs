using System;
using System.Text.Json;

namespace BankApp
{
    class Program
    {
        static void Main(string[] args)
        {

            var jsonString = File.ReadAllText("/Users/ahmadqasem/Desktop/BankApp/BankApp/File_1.json");
            var bankAccounts = JsonSerializer.Deserialize<List<BankAccount>>(jsonString);

            var julyAccountsCount = bankAccounts.Count(e => e.CreationDate.Month == 7);
            Console.WriteLine($"Number of accounts created in July: {julyAccountsCount}");

            var topThreeAccounts = bankAccounts.OrderBy(a => a.Balance).TakeLast(3);
            Console.WriteLine("Top 3 customers with highest balances:");
            foreach (var account in topThreeAccounts)
            {
                Console.WriteLine($"Name: {account.Name}, Balance: {account.Balance:C}");
            }

            var totalBalance = bankAccounts.Sum(a => a.Balance);
            Console.WriteLine($"Total sum of all account balances: {totalBalance:C}");



            var groupedAccounts = bankAccounts.GroupBy(a =>
           {
               if (a.Balance < 5000)
                   return "Low Balance";
               else if (a.Balance >= 5000 && a.Balance <= 10000)
                   return "Medium Balance";
               else
                   return "High Balance";
           });

            Console.WriteLine("Accounts grouped by balance:");
            foreach (var group in groupedAccounts)
            {
                Console.WriteLine($"{group.Key}: {group.Count()} accounts");
            }

        }



    }
}
