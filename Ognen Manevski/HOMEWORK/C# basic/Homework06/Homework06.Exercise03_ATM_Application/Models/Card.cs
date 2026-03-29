using System.Globalization;

namespace Homework06.Exercise03_ATM_Application.Models
{
    public class Card
    {
        private string CardNumber { get; set; }
        private string PIN { get; set; }
        private double Balance { get; set; }

        public Card(string cardNumber, string pin, double balance = 0)
        {
            CardNumber = TrimCardNumber(cardNumber);
            PIN = pin;
            Balance = balance;
        }

        // methods
        public bool CheckExists(string cardNumber)
        {
            cardNumber = TrimCardNumber(cardNumber);
            return cardNumber == CardNumber;
        }

        public bool Authenticate(string pin)
        {
            return pin == PIN;
        }

        public string GetBalance()
        {
            string balance = FormatAmount(Balance);
            return balance;
        }

        public bool Withdraw(double amount)
        {
            amount = Math.Abs(amount);

            if (amount <= Balance)
            {
                Balance -= amount;
                return true;
            }
            return false;
        }

        public void Deposit(double amount)
        {
            amount = Math.Abs(amount);
            Balance += amount;
        }

        //utils
        public string FormatAmount(double amount)
        {
            return amount.ToString("C2", new CultureInfo("en-US")); // USD currency with 2 decimals
        }

        public string TrimCardNumber(string cardNo)
        {
            return cardNo.Replace("-", "").Replace("_", "").Replace(" ", "");
        }
    }
}