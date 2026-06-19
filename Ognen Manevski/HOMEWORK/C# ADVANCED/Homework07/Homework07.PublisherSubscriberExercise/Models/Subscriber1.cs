namespace Homework07.PublisherSubscriberExercise.Models;

public class Subscriber1 : SubscriberBase
{
    public Subscriber1(string subscriberName) : base(subscriberName)
    {
    }

    public override void ReadMessage(string message)
    {
        Console.WriteLine($"Subscriber {SubscriberName} received message: {message}");
        Console.WriteLine("Nice! I like this video!");
    }
}
