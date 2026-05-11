/*
3. Create a console application that plays rock - paper - scissors 🔹

    There should be a menu with three options:

        Play
            The user picks rock paper or scissors option
            The application picks rock paper scissors on random
            The user pick and the application pick are shown on the screen
            The application shows the winner
            The application saves 1 score to the user or the computer in the background
            When the user hits enter it returns to the main menu

        Stats
            It shows how many wins the user and how many wins the computer has
            It shows percentage of the wins and loses of the user
            When the user hits enter it returns to the main menu

        Exit
            It closes the application

🤖 Let's ask AI

Prompt:

How to generate a random choice between rock, paper and scissors in C#?

Refine:

    "using Random class"
    "best practice for random in console apps"

Try:

How to structure a console app with menu and separate logic (services)?

🤖 Bonus AI Prompts (for better design)

How would you structure this application using clean code principles?

What are common mistakes when building console menu applications?

How can I track score in memory without using a database?

 */

//data

using Class_Exercises.Exercise03.Enums;
//^I had an error if i defined the enum here so i moved it to a separate file

HashSet<(Choice, Choice)> playerWins = new HashSet<(Choice, Choice)>
{
    (Choice.Rock, Choice.Scissors),
    (Choice.Paper, Choice.Rock),
    (Choice.Scissors, Choice.Paper)
};

int playerScore = 0;
int pcScore = 0;

string pad = new string('=', 10);
string sep = new string('-', 50);
string menu = $@"
{pad} MENU {pad}
Play [1]
Stats [2]
Exit [any key]
";


//logic
int getPCChoice()
{
    //Random random = new Random();
    //return random.Next(1, 4);
    return Random.Shared.Next(1, 4);  // ✅ Uses shared thread-safe instance
}

void determineWinner(Choice player, Choice pc)
{
    if (player == pc) //tie
    {
        Console.WriteLine("It's a tie!");
        return;
    }
    if (playerWins.Contains((player, pc))) //player wins
    {
        Console.WriteLine("Player wins!");
        playerScore++;
        return;
    }
    Console.WriteLine("PC wins!");
    pcScore++;
}

void printChoice(Choice choice, string player)
{
    Console.WriteLine($@"{player} chose {choice.ToString().ToUpper()}!");
}

void printResults()
{
    Console.WriteLine(sep);
    Console.WriteLine($"Player Score: {playerScore}");
    Console.WriteLine($"PC Score: {pcScore}");
    int totalGames = playerScore + pcScore;
    if (totalGames > 0)
    {
        double playerWinPerc = (double) playerScore / totalGames; //(double) to avoid integer division
        string percString = $"{playerWinPerc:P}";//format as percentage
        Console.WriteLine($"Player Win Percentage: {percString}");
    }
    Console.WriteLine(sep);
}

void playGame()
{
    Console.WriteLine("Pick your choice: Rock [1], Paper [2], Scissors [3]");
    string input = Console.ReadLine();

    int parsedInt = 0;

    while (!int.TryParse(input, out parsedInt) || parsedInt < 1 || parsedInt > 3)
    {
        Console.WriteLine("Invalid choice! Please pick 1, 2 or 3.");
        Console.WriteLine("Rock [1], Paper [2], Scissors [3]");
        input = Console.ReadLine();
    }

    Choice playerChoice = (Choice)parsedInt;

    int pcChoiceInt = getPCChoice();
    Choice pcChoice = (Choice)pcChoiceInt;

    printChoice(playerChoice, "Player");
    printChoice(pcChoice, "PC");
    determineWinner(playerChoice, pcChoice);
    Console.WriteLine(sep);
}

void gameLoop()
{
    while (true)
    {
        Console.Clear();
        playGame();

        Console.WriteLine("Play again? [Y], Main Menu [any]");
        string choice = Console.ReadLine();
        if (choice?.ToLower() != "y")
        {
            break;
        }
    }
}


//app

while (true)
{
    Console.WriteLine($"{pad} ROCK - PAPER - SCISSORS {pad}");
    Console.WriteLine(menu);

    string input = Console.ReadLine();

    switch (input)
    {
        case "1": //play
            {
                gameLoop();
                break;
            }
        case "2": //stats
            {
                Console.Clear();
                printResults();
                break;
            }
        default: //exit
            {
                Console.WriteLine("Exiting...");
                return;
            }
    }
}



