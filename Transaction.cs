using System.Text.Json.Serialization;

namespace BankApp
{
    public class Transaction
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }

       

        [JsonPropertyName("LastName")]
        public string Name { get; set; }
        public decimal Balance { get; set; }
        public DateTime OperationTime { get; set; }
        public override string ToString()
        {
            return $"Transaction ID: {Id}, Name: {Name}, Balance: {Balance:C}, Operation Time: {OperationTime:yyyy-MM-dd HH:mm:ss}";
        }
    }
}
