namespace Homework07.PublisherSubscriberExercise.Models;

public class Subscriber2 : SubscriberBase
{
    public Subscriber2(string subscriberName) : base(subscriberName)
    {
    }
    public override void ReadMessage(string message)
    {
        Console.WriteLine($"Subscriber {SubscriberName} received message: {message}");
        Console.WriteLine("Yikes! This is not my favorite video.");
    }
}
