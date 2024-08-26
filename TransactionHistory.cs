using System.Text.Json.Serialization;

namespace BankApp
{
    public class TransactionHistory
    {
        [JsonPropertyName("ID")]
        public int ID { get; set; }
        public int AccountID { get; set; }

        public decimal Amount { get; set; }
        public string? TransactionDetails { get; set; }// details as type of transaction deposit or withdraw

        public DateTime TransactionTime { get; set; }
        public override string ToString()
        {
            return $"Transaction ID: {ID}, Balance: {Amount:C}, Transaction Time: {TransactionTime:yyyy-MM-dd HH:mm:ss}";
        }
    }
}
