using System;
using System.Text.Json;

namespace BankApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var customerJsonFile = "/Users/ahmadqasem/Desktop/BankApp/BankApp/JSON/Customer.json";
            var accountJsonFile = "/Users/ahmadqasem/Desktop/BankApp/BankApp/JSON/AccountBank.json";
            var transactionJsonFile = "/Users/ahmadqasem/Desktop/BankApp/BankApp/JSON/Transaction.json";


            var customers = JsonSerializer.Deserialize<List<Customer>>(File.ReadAllText(customerJsonFile));
            var accounts = JsonSerializer.Deserialize<List<BankAccount>>(File.ReadAllText(accountJsonFile));
            var transactions = JsonSerializer.Deserialize<List<TransactionHistory>>(File.ReadAllText(transactionJsonFile));


            //Identify the number of accounts that were created during the month of July.
            int monthNumber = 7;
            var numberOfAccounts = accounts.Where(account => account.CreationDate.Month == monthNumber).Count();
            Console.WriteLine($" Number of Acounts in month #{monthNumber}: {numberOfAccounts}");
            Console.WriteLine("-----------------------------------------------------------");



            //Display the name, email, and balance of the three customers with the highest balance in the bank.
            var highestThreeCustomersBalance = customers
            .Join(
                accounts,
                customer => customer.ID,
                account => account.UserID,
                (customer, account) => new { customer.FirstName, customer.LastName, customer.Email, account.Balance })
            .OrderBy(c => c.Balance)
            .TakeLast(3);

            Console.WriteLine("Highest Three customers with highest balances in the Bank:");
            foreach (var customer in highestThreeCustomersBalance)
            {
                Console.WriteLine($"Customer Name: {customer.FirstName} {customer.LastName},Customer Email: {customer.Email}, Balance: {customer.Balance}");
            }
            Console.WriteLine("-----------------------------------------------------------");



            //Calculate the total sum of all account balances in the bank
            var totalBalance = accounts.Sum(account => account.Balance);
            Console.WriteLine($" Total Sum of All Account Balance{totalBalance}");
            Console.WriteLine("-----------------------------------------------------------");




            //List the complete transaction history for the most active customer in the bank during the last month.
            Console.WriteLine("-----------------------------------------------------------");




            /*
             Group accounts based on their balance as follows:
             Balance < $5,000: "Low Balance"
             Balance between $5,000 and $10,000: "Medium Balance"
             Balance > $10,000: "High Balance"
             */
            var accountsGroup = accounts.GroupBy(account =>
            {
                if (account.Balance > 10000) return "high Balance";
                else if (account.Balance > 5000) return "medium Balance";
                else return "low Balance";
            });
            Console.WriteLine($" account grouped by balance");
            foreach (var account in accountsGroup)
            {
                Console.WriteLine($"{account.Key} : {account.Count()}");
            }
            Console.WriteLine("-----------------------------------------------------------");
        }



    }
}
