namespace Homework06.Exercise03_ATM_Application.Models;

public class Customer
{
    public string Name { get; set; }

    private Card[] Cards;

    private Card ActiveCard { get; set; } //track which card is in use

    public Customer(string name, Card[] cards = null)
    {
        Name = name;
        Cards = cards;
    }

    // methods

    //authentication and search
    //public bool methods
    public bool AuthenticateCard(string cardNumber, string pin)
    {
        Card? card = FindCard(cardNumber);
        if (card != null && card.Authenticate(pin))
        {
            ActiveCard = card; // Set active card for easy access in future operations
            return true;
        }
        return false;
    }

    public bool CardExists(string cardNumber)
    {
        return FindCard(cardNumber) != null;
    }

    //private helper to access card objects without exposing
    private Card? FindCard(string cardNumber)
    {
        if (Cards == null || Cards.Length == 0) // !!@#!@
        {
            return null;
        }

        foreach (Card card in Cards)
        {
            if (card.CheckExists(cardNumber))
            {
                return card;
            }
        }
        return null;
    }

    // forwarding card operations for privacy

    public string GetBalance()
    {
        return ActiveCard.GetBalance();
    }

    public bool Withdraw(double amount)
    {
        return ActiveCard.Withdraw(amount);
    }

    public void Deposit(double amount)
    {
        ActiveCard.Deposit(amount);
    }

    public string FormatAmount(double amount)
    {
        return ActiveCard.FormatAmount(amount);
    }

    // Add new card to customer
    public void AddCard(Card newCard)
    {
        if (Cards == null) // !@#!@#!
        {
            Cards = new Card[] { newCard };
        }
        else
        {
            Array.Resize(ref Cards, Cards.Length + 1);
            Cards[Cards.Length - 1] = newCard;
        }
    }

    //generate unique card number
    public string GenerateCardNumber()
    {
        Random random = new Random();

        string cardNumber = "";

        while (true)
        {
            string temp = "";

            for (int i = 0; i < 12; i++)
            {
                temp += random.Next(0, 10).ToString(); // random 0 - 9
            }

            if (!CardExists(temp)) return temp; //only if unique
        }
    }
}

