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
        private List<string> transactionHistory;


        public BankAccount(decimal threshold, decimal balance, string accountNumber)
        {
            this.threshold = threshold;
            this.accountNumber = accountNumber;
            this.balance = balance;
            this.transactionHistory = new List<string>();
        }

        public event BalanceChangedHandler? BalanceChanged;

        public decimal Balance
        {
            get { return balance; }
            set { balance = value; }
        }

        public List<string> TransactionHistory
        {
            get { return transactionHistory; }
        }

        public void Deposit(AccountHolder holderInfo, decimal amount)
        {
            if (amount > 3000)
            {
                Console.WriteLine($"Hi {holderInfo.Name}, Transaction canceled: Please depose less than 3000");
            }
            var oldBalance = Balance;
            Balance += amount;
            transactionHistory.Add($"depose {amount} to account");
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
            transactionHistory.Add($"withdraw {amount} from account");
            BalanceChanged?.Invoke("Withdraw", this, oldBalance);
        }

    }
}