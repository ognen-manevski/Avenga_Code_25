using System.Diagnostics;

Console.WriteLine("============ ASYNC/AWAIT ============");

void SendMessage(string message)
{
    Console.WriteLine("Sending message .....");

    Thread.Sleep(2000);

    Console.WriteLine($"Message {message} sent successfully!");
    Console.WriteLine($"Current thread ID: {Thread.CurrentThread.ManagedThreadId}"); //main
}
;

async Task SendMessageAsync(string message)
{
    Console.WriteLine("Sending message .....");

    await Task.Delay(3000);

    Console.WriteLine($"Current thread ID: {Thread.CurrentThread.ManagedThreadId}");

    Console.WriteLine($"Message {message} sent successfully!");

}
;

void ShowAd()
{
    Console.WriteLine("While you wait, here's an ad. Buy the new 'iPhone' for special price!");
}

Stopwatch stopwatch = new Stopwatch();

stopwatch.Restart();

SendMessage("Hello Avenga Academy");

ShowAd();

stopwatch.Stop();

Console.WriteLine($"Total time: {stopwatch.ElapsedMilliseconds} ms");


Console.WriteLine($"============ Async WITHOUT await - Fire and Forget ============");

stopwatch.Restart();

SendMessageAsync("Hello Avenga Academy");
ShowAd();

stopwatch.Stop();
Console.WriteLine($"Total time: {stopwatch.ElapsedMilliseconds} ms");



//with await

Console.WriteLine("========== Async with Await ============");

stopwatch.Restart();

await SendMessageAsync("Hello Avenga Academy");
ShowAd();

stopwatch.Stop();

Console.WriteLine($"Total time: {stopwatch.ElapsedMilliseconds} ms");


//

async Task<int> GetProductPriceAsync() {
    await Task.Delay(1000);
    return 5335;
};

int productPrice = await GetProductPriceAsync(); // we can await the result directly, but it will wait until the task is completed, but it doesn't block the main thread

Console.WriteLine($"The product price is: {productPrice}");













Console.ReadLine();

