using System;
using System.Text;
using System.Transactions;

namespace BankApp
{

    public class BankAccount
    {

        public int ID { get; set; }
        public int UserID { get; set; }
        public string? AccountNumber { get; set; }
        public DateTime CreationDate { get; set; }

        public decimal Balance { get; set; }
        public string? Type { get; set; }

    }
}
