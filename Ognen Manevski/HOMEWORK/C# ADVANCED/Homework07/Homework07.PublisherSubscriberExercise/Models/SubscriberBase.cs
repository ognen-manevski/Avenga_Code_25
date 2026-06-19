namespace Homework07.PublisherSubscriberExercise.Models;

public abstract class SubscriberBase
{
    //Create 2 Subscriber classes that:

    //Have a method that matches the delegate signature
    //Print the message in their own way
    public string SubscriberName { get; set; }

    public SubscriberBase(string subscriberName)
    {
        SubscriberName = subscriberName;
    }

    public abstract void ReadMessage(string message);

}
