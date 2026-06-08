Console.WriteLine( "=================== THREADS ===================");


Console.WriteLine($"Main Thread ID: {Thread.CurrentThread.ManagedThreadId}");

// synchronous

static void SendMessages()
{
    Console.WriteLine("Getting Ready...");
    //Thread.Sleep(2000);

    Console.WriteLine("First message arrived!");
    //Thread.Sleep(2000);

    Console.WriteLine("Second message arrived!");
    //Thread.Sleep(2000);

    Console.WriteLine("Third message arrived!");
    Console.WriteLine("All messages are received!");

    Console.ReadLine();
}

//SendMessages();


// asynchronous

void SendMessagesWithThreads()
{
    Console.WriteLine("Getting Ready...");
    Random rnd = new Random();

    Thread t1 = new Thread(() =>
    {
        int delay = rnd.Next(500, 2000);
        Thread.Sleep(delay);

        Console.WriteLine($"First message arrived after {delay} ms! [Thread ID: {Thread.CurrentThread.ManagedThreadId}]");
    });

    Thread t2 = new Thread(() =>
    {
        int delay = rnd.Next(500, 2000);
        Thread.Sleep(delay);

        Console.WriteLine($"Second message arrived after {delay} ms! [Thread ID: {Thread.CurrentThread.ManagedThreadId}]");
    });

    Thread t3 = new Thread(() =>
    {
        int delay = rnd.Next(500, 2000);
        Thread.Sleep(delay);

        Console.WriteLine($"Third message arrived after {delay} ms! [Thread Name: {Thread.CurrentThread.Name}]");
    })
    { Name = "Our Thread 3" };

    t1.Start();
    t2.Start();
    t3.Start();

    Console.ReadLine();
}

//SendMessagesWithThreads();

