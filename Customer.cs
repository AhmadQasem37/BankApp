using System;
namespace BankApp
{
    public class Customer
    {


        // Primary key 
        public int ID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Gender { get; set; }
        public string? Phone { get; set; }
        public string? Password { get; set; }
        public DateTime DateOfBirth { get; set; }


    }
}