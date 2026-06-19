namespace Homework07.PublisherSubscriberExercise.Models;

public class Publisher
{
    //Create a Publisher class that :

    //    Has a delegate that accepts a string message

    //    Has an event based on that delegate
    //    Has a method ProcessData(string message) that:

    //    Simulates some work (can use delay)
    //    Calls a method that raises the event

    public Publisher()
    {
        
    }

    public delegate void MessageDelegate(string message);

    public event MessageDelegate? OnMessageEvent;

    public void ProcessData(string message)
    {
        Console.WriteLine("Sending message...");
        Thread.Sleep(1000);
        Console.WriteLine("Messages sent!");
        OnMessageEvent?.Invoke(message);
    }

}
