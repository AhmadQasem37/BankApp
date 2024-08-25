using System;
using System.Text;
using System.Transactions;

namespace BankApp
{
    public delegate void BalanceChangedHandler(string transactionName, BankAccount account, decimal oldBalance);

    public class BankAccount
    {

        public int Id { get; set; }
        public string Name { get; set; }
        
        public decimal Balance { get; set; }
       
        public DateTime CreationDate { get; set; }
        public List<Transaction> TransactionHistory { get; set; }

       
        public BankAccount()
        {
            TransactionHistory = new List<Transaction>();
        }
        public BankAccount(int id,  string Name,  decimal balance)
        {
            Id = id;
            Name = Name;
           
            Balance = balance;
            TransactionHistory = new List<Transaction>();
        }
        public event BalanceChangedHandler? BalanceChanged;

        

        

        

    }
}