//==========================================
#region Loops
//==========================================

for (int i = 0; i < 10; i++)
{
    Console.WriteLine(i);
}

for (int i = 10; i > 0; i--)
{
    Console.WriteLine(i);
}


//infinite loop

for (; ; )
{
    Console.WriteLine("This will run forever");

    var x = Console.ReadLine();

    if (x != null)
    {
        break;
    }
}


Console.WriteLine("Creating a droid army");

for (int i = 0; i < 10; i++)
{
    Console.WriteLine("Assembling droid batalion " + i);

    //Thread.Sleep(1000);

    if (i == 5)
    {
        Console.WriteLine("Problem assembling droid batalion " + i);
        continue;
    }

    if (i == 7)
    {
        Console.WriteLine("Droid assembler broke down");
        break;
    }

    Console.WriteLine("Droid Batalion " + i + " Is Operational");
}

#endregion
//==========================================


//==========================================
#region While
//==========================================
int count = 0;

Console.WriteLine("While Loop");

while (count <= 10)
{
    Console.WriteLine(count);
    count++;
}


while (true)
{
    Console.WriteLine("This will run forever. Type X to stop.");

    string x = Console.ReadLine();

    if (x == "X" || x == "x")
    {
        break;
    }
}


//create a droid army with while loop

int droidCount = 0; 

while (droidCount < 10)
{
    Console.WriteLine("Cloning droid " + droidCount);
    if(droidCount == 5)
    {
        Console.WriteLine("Problem in cloning droid " + droidCount);
        droidCount++;
        continue;
    }

    if(droidCount == 7) {
        Console.WriteLine("Cloning machine broke down");
        break;
    }

    Console.WriteLine("Droid " + droidCount + " Is Operational");
    droidCount++;
}

#endregion
//==========================================


//==========================================
#region Do While
//==========================================


Console.WriteLine("========= Do While Loop ============");

int doCount = 0;

do
{
    Console.WriteLine(doCount);
    doCount++;
} while (doCount <= 10);


do
{
    Console.WriteLine("This will be executed once");
} while (false);

#endregion
//==========================================