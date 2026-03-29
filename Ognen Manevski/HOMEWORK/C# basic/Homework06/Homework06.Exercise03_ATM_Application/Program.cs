using Homework06.Exercise03_ATM_Application.Models;
using Homework06.Utilities;

//=====================================
#region Exercise 3 - ATM Application
//=====================================

/*
Task 3 Create an ATM application.

A customer should be able to authenticate with card number and pin
and should be greeted with a message greeting them by full name.

After that they can choose one of the following:

    Balance checking
    Cash withdrawal
    Cash deposition

In order for the ATM app to work we need Customers.

Bonus: The balance and pin should not be public
Bonus: Ask the customer if they want another action
Bonus: Add an option to register a new card


🧠 Design Hint – Separate Methods

This task is too big for one method.
Split it into logical parts:

    Authentication (card + pin)
    ATM menu
    Balance operations
    Deposit / Withdraw
    Repeating actions
*/

#endregion
//=====================================


Customer[] customers = new Customer[]
{
    new Customer("John Doe", new Card[]{ new Card("123-456-789-123", "1234", 1000.00) }),
    new Customer("Jane Smith", new Card[]
    {
        new Card("987-654-321-098", "4321", 2000.00),
        new Card("111-111-111-111", "1234", 3000.00) //2 cards
    }),
    new Customer("Alice Johnson", new Card[] { new Card("555-555-555-555", "1111", 4000.00) })
};



bool ATMApp()
{
    Console.Clear();

    Console.WriteLine("=============== Welcome to the ATM App! ===============");

    Console.WriteLine(
$@"
+{new string('-', 8)} ATM Menu {new string('-', 8)}+
| {"1. Insert Card",-24} |
| {"2. Register New User",-24} |
+{new string('-', 26)}+
");

    Console.WriteLine("Please enter your choice:");
    bool exit = false;
    while (!exit)
    {
        string choice = Console.ReadLine();
        switch (choice)
        {
            case "1":
                AuthenticateUser();
                break;
            case "2":
                RegisterNewUser();
                break;
            default: Console.WriteLine("Invalid choice. Please pick [1] or [2]:"); continue;
        }
        exit = true;
    }
    return true;
}

while (ATMApp()) ; //run forever

//==================================
#region ATM Menu Options
//==================================

void AuthenticateUser()
{
    Console.WriteLine("Please Log in with your card number and PIN:");

    //bool cardOk = false;

    string cardNumber = GetCardNumberInput();

    foreach (Customer customer in customers)
    {
        if (customer.CardExists(cardNumber))
        {
            short attempts = 3;
            while (attempts > 0)
            {

                bool pinOk = false;
                string pin = "";

                while (!pinOk)
                {
                    Console.Write("PIN: ");
                    pin = Console.ReadLine();

                    if (pin.Length != 4)
                    {
                        Console.WriteLine("PIN must be 4 digits long.");
                        continue;
                    }
                    pinOk = true;
                }

                if (customer.AuthenticateCard(cardNumber, pin))
                {
                    LoggedInMenu(customer);
                    return;
                }
                attempts--;
                Console.WriteLine($"Incorrect PIN. You have {attempts} attempts left.");
            }
            Console.WriteLine("Too many incorrect attempts. Exiting.");
            return;
        }
    }
    Console.WriteLine("Card number does not exist.");
}


void RegisterNewUser()
{
    Console.Clear();

    Console.WriteLine($"{new string('-', 5)} Register a New User {new string('-', 5)}");

    Console.WriteLine("Please Enter your Full Name");
    string name = Console.ReadLine();

    if (name != null)
    {

        Console.WriteLine("Do you own a card? (y/n)");
        string ownsCard = Console.ReadLine();

        if (ownsCard.ToLower() == "y")
        {
            string CardNumber = GetCardNumberInput();
            string PIN = GetPinInput();

            Card newCard = new Card(CardNumber, PIN); //balance is 0

            Array.Resize(ref customers, customers.Length + 1);
            customers[customers.Length - 1] = new Customer(name, new Card[] { newCard });
        }
        else
        {
            Customer newCustomer = new Customer(name);

            //add customer to array
            Array.Resize(ref customers, customers.Length + 1);
            customers[customers.Length - 1] = newCustomer;

            AddNewCard(newCustomer);
        }

        Console.WriteLine($"{new string('-', 5)} Welcome {name} {new string('-', 5)}");
        Console.WriteLine($"Your account has been successfully created.");
        Console.WriteLine();
        Console.WriteLine("Enter any key to return to the main menu...");
        Console.ReadKey();
    }
    else
    {
        Console.WriteLine("Name cannot be empty. Returning to main menu.");
    }
    Console.WriteLine(new string('-', 31));
}

#endregion
//==================================


void LoggedInMenu(Customer customer)
{
    Console.Clear();

    Console.WriteLine($"=============== Welcome {customer.Name}! ===============");

    bool exit = false;

    while (!exit)
    {
        Console.WriteLine(
$@"
+{new string('-', 6)} Main Menu {new string('-', 6)}+
| {"1. Check Balance",-21} |
| {"2. Withdraw Cash",-21} |
| {"3. Deposit Cash",-21} |
| {"4. Register New Card",-21} |
| {"x. Exit",-21} |
+{new string('-', 25)}+
");

        Console.WriteLine("Please enter your choice:");
        bool back = false;
        while (!back)
        {
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    CheckBalance(customer);
                    break;
                case "2":
                    WithdrawCash(customer);
                    break;
                case "3":
                    DepositCash(customer);
                    break;
                case "4":
                    AddNewCard(customer);
                    break;
                case "x": exit = true; break;
                default: Console.WriteLine("Invalid choice. Please pick [ 1, 2, 3, 4 ] or [x] to exit:"); continue;
            }
            back = true;
        }
    }
}


//==================================
#region Logged In Menu Options
//==================================

void CheckBalance(Customer customer)
{
    Console.Clear();

    string balance = customer.GetBalance();
    Console.WriteLine($"{new string('-', 5)} Balance {new string('-', 5)}");
    Console.WriteLine($"Your current balance is: {balance}");
    Console.WriteLine(new string('-', 19));
}

void WithdrawCash(Customer customer)
{
    Console.Clear();

    bool ok = false;
    while (!ok)
    {
        Console.WriteLine($"{new string('-', 5)} Withdraw Cash {new string('-', 5)}");

        Console.WriteLine("Enter the amount to withdraw or [0] to go back");

        double amount = Utilities.GetNumInput("Withdraw: ", true);

        if (amount == 0) { Console.Clear(); break; }

        ok = customer.Withdraw(amount);

        if (ok) Console.WriteLine($"You have successfully withdrawn {customer.FormatAmount(amount)}.");
        else Console.WriteLine("Insufficient Funds.");

        Console.WriteLine(new string('-', 25));
    }
}

void DepositCash(Customer customer)
{
    Console.Clear();

    Console.WriteLine($"{new string('-', 5)} Deposit Cash {new string('-', 5)}");

    Console.WriteLine("Enter the amount to deposit or [0] to go back");

    double amount = Utilities.GetNumInput("Deposit: ", true);

    if (amount == 0) { Console.Clear(); return; }

    customer.Deposit(amount);
    Console.WriteLine($"You have successfully deposited {customer.FormatAmount(amount)}.");

    Console.WriteLine(new string('-', 24));
}


void AddNewCard(Customer customer)
{
    Console.Clear();

    Console.WriteLine($"{new string('-', 5)} Register a New Card {new string('-', 5)}");

    string newCardNumber = customer.GenerateCardNumber();

    string newPIN = GetPinInput(true); // true -> ask for new pin with confirmation

    customer.AddCard(new Card(newCardNumber, newPIN));

    Console.WriteLine(new string('-', 31));
    Console.WriteLine();
    Console.WriteLine($"New card registered successfully!");
    Console.WriteLine($"Your new card number is: {FormatCardNumber(newCardNumber)}");
    Console.WriteLine();

    Console.WriteLine(new string('-', 31));
}

#endregion
//==================================



//==================================
#region Helpers
//==================================


string GetPinInput(bool isNew = false)
{
    bool pinOk = false;
    string pin = "";

    while (!pinOk)
    {
        if (isNew)
        {
            Console.Write("Enter a new PIN for the card: ");
        }
        else
        {
            Console.Write("PIN: ");
        }
        pin = Console.ReadLine();

        if (pin.Length != 4)
        {
            Console.WriteLine("PIN must be 4 digits long.");
            continue;
        }

        if (isNew)
        {
            string confirmPin = "";

            Console.Write("Confirm PIN: ");
            confirmPin = Console.ReadLine();

            if (pin != confirmPin)
            {
                Console.WriteLine("PINs do not match. Please try again.");
                Console.WriteLine(new string('-', 31));
                continue;
            }
        }

        pinOk = true;
    }

    return pin;
}

string GetCardNumberInput()
{
    bool cardOk = false;
    string cardNumber = "";

    while (!cardOk)
    {
        Console.Write("Card Number:");
        cardNumber = Console.ReadLine();

        if (cardNumber.Length < 12)
        {
            Console.WriteLine("Card number must be 12 digits long.");
            continue;
        }
        cardOk = true;
    }

    return cardNumber;
}

string FormatCardNumber(string cardNumber)
{
    //123-456-789-123
    string formatted = "";
    int i = 0;
    foreach (char c in cardNumber)
    {
        if (i % 3 == 0 && i != 0) formatted += "-";
        formatted += c;
        i++;
    }
    return formatted;
}


#endregion
//==================================

