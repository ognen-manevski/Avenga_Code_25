namespace Class15.PracticesAndPrinciple.GoodPractices;

internal class IfElse
{
    public void CheckTwoNumbers(int a, int b)
    {
        //BAD EXAMPLE:

        if (a <= 100 && b <= 100)
        {
            if (a % 2 == 0 && b % 2 == 0)
            {
                if (a > 0 && b > 0)
                {
                    if (a == b)
                    {
                        Console.WriteLine("The numbers are equal");
                    }
                    else
                    {
                        Console.WriteLine("The numbers are not equal");
                    }
                }
            }
        }

        //GOOD EXAMPLE:

        if ((a > 100 || a < 0) || (b > 100 || b < 0)) return;
        if (a % 2 != 0 && b % 2 != 0) return;
        if (a != b) Console.WriteLine("The numbers are not equal");
        Console.WriteLine("The numbers are equal");



    }
}
