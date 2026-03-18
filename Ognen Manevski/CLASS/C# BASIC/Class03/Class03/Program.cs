//==========================================
#region Exercise 1
//==========================================

Console.WriteLine("========== Exercise 1 ============");

Console.WriteLine("Enter a number [Up To]:");

int tryUpTo = TryParse(Console.ReadLine(), out int upTo);
while (int i = 1; i <= upTo; i++)
    {
    Console.WriteLine(i);
}


Console.WriteLine("Enter a number [From]:");
int tryFrom = TryParse(Console.ReadLine(), out int from);
while (int i = from; i >= 1; i--)
    {
    Console.WriteLine(i);
}


#endregion
//==========================================

