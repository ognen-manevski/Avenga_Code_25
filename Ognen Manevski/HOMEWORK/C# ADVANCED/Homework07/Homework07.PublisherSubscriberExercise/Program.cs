//🧪 EXERCISE

//In Main:

//    Create publisher
//    Create both subscribers
//    Subscribe both to the event
//    Trigger ProcessData()
//    Unsubscribe one subscriber
//    Trigger ProcessData() again


using Homework07.PublisherSubscriberExercise.Models;

Publisher publisher = new Publisher();

Subscriber1 subscriber1 = new Subscriber1("Alice");
Subscriber2 subscriber2 = new Subscriber2("Bob");

publisher.OnMessageEvent += subscriber1.ReadMessage;
publisher.OnMessageEvent += subscriber2.ReadMessage;

publisher.ProcessData("Hello, subscribers. Video 1 is out!");

publisher.OnMessageEvent -= subscriber2.ReadMessage;

publisher.ProcessData("Hello, subscribers. Video 2 is out!");
