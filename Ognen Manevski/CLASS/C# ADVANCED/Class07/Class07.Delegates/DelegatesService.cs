namespace Class07.Delegates;

internal class DelegatesService
{

    private delegate int SubtractDelegate(int a, int b);

    private delegate void SayDelegate(string text);

    private delegate double CalculationDelegate(int a, int b);

    private void SayHello(string word)
    {
        Console.WriteLine(word);
    }


    private void SayWhatever(string whatever, SayDelegate sayMethod)
    {
        sayMethod(whatever);
    }

    private double Calculate (int a, int b, CalculationDelegate method)
    {
        return method(a, b);
    }

    private double Product(int a, int b)
    {
        return a * b;
    }

    public void Run()
    {
        Console.WriteLine("Hello, World!");

        Func<int, int, int> subtractFunc = (a, b) => a - b;

        Console.WriteLine(subtractFunc(10, 20));

        Action<string, ConsoleColor> printInColor = (text, color) =>
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        };

        printInColor("This is red text", ConsoleColor.Red);


        SubtractDelegate subtract = (a, b) => a - b;

        CalculationDelegate subtract3 = (a, b) => a - b;

        Console.WriteLine(subtract(20, 5));


        SayDelegate sayHello = new SayDelegate(word => Console.WriteLine(word));

        sayHello("Hello from SayDelegate!");

        SayDelegate sayHelloAgain = new SayDelegate(SayHello);
        SayDelegate sayHelloAgain2 = SayHello; //the same as above, but more concise

        sayHelloAgain("Hello again from SayDelegate!");

        SayWhatever("Whatever", sayHello);
        SayWhatever("Whatever", SayHello);
        SayWhatever("Whatever", text => Console.WriteLine(text));
        SayWhatever("Whatever", text => printInColor(text, ConsoleColor.Green));


        printInColor("======= Calculation Delegate Example =======", ConsoleColor.Yellow);

        double sum = Calculate(10, 20, (a, b) => a + b);
        printInColor($"Sum: {sum}", ConsoleColor.Yellow);

        double subtract2 = Calculate(10, 20, subtract3);
        Console.WriteLine($"Subtract: {subtract2}");


        double product = Calculate(10, 20, Product);
        Console.WriteLine($"Product: {product}");





    }
}
