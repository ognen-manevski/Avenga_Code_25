using Class07.Events.Enums;
using System.Globalization;

namespace Class07.Events.Models;

public class Market
{

    public delegate void PromotionHandler(ProductType productType);

    private event PromotionHandler OnPromotionSent;

    public int Id { get; set; }
    public string Name { get; set; }
    public ProductType ProductTypeOnPromotion { get; set; }

    List<string> SubscriberEmails { get; set; } = [];
    List<string> UnsubscribeReasons { get; set; } = [];


    public void SunscribeForPromotion(PromotionHandler handler, string email)
    {
        OnPromotionSent += handler; // add the handler to the event list
        SubscriberEmails.Add(email);
    }

    public void SendPromotion()
    {
        Console.WriteLine($"Market {Name} is sending promotions for {ProductTypeOnPromotion}.");
        Console.WriteLine("Sending...");
        Thread.Sleep(500);
        NotifySubscribers();
    }

    private void NotifySubscribers()
    {
        OnPromotionSent(ProductTypeOnPromotion);
        //OnPromotionSent?.Invoke(ProductTypeOnPromotion);     
    }


    public void UnsubscribeFromPromotion(
        PromotionHandler handler,
        string email,
        string reason)
    {
        OnPromotionSent -= handler;
        SubscriberEmails.Remove(email);
        UnsubscribeReasons.Add(reason);

    }



}
