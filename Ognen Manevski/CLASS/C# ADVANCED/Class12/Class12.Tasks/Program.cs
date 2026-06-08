Console.WriteLine("======================== TASKS ===================");

//task staus lifetime

//old way + we must start manually
//Task myTask = new Task(() =>{ });


//new way + starts immediately
Task myTask = Task.Run(() =>
{
    Thread.Sleep(2000);
    Console.WriteLine("Running after 2000 ms");
});

Console.WriteLine($"Right after start {myTask.Status}");
Thread.Sleep(500);
Console.WriteLine($"While running: {myTask.Status}");
myTask.Wait();
Console.WriteLine($"After completion: {myTask.Status}");


//task<T> - returning a value

Task<int> valueTask = Task.Run(() =>
{
    Thread.Sleep(1500);
    return 300;
});

//valueTask.Wait(); -> we can wait for the result directly
Console.WriteLine(valueTask.Result); //-> or we can get the result directly, but it will wait until the task is completed
                                     // but it blocks the main thread, so it's not recommended

Console.WriteLine($"Status after getting result: {valueTask.Status}");


Console.WriteLine("============= 20 Tasks =====================");

Random rnd = new Random();

for (int i = 0; i < 20; i++)
{
    int temp = i; // to avoid closure issue
    Task.Run(() =>
    {
        int delay = rnd.Next(500, 2000);
        Thread.Sleep(delay);
        Console.WriteLine($"Task {temp} done after {delay} ms. [Thread ID: {Thread.CurrentThread.ManagedThreadId}]");
    });
};

Console.WriteLine($"Main thread ID: {Thread.CurrentThread.ManagedThreadId}");






Console.ReadLine();