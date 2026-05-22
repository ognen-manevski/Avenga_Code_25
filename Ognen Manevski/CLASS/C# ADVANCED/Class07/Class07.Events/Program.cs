using Class07.Events.Models;
using Class07.Events.Enums;

Console.WriteLine("============== Super Market ===============");

Market market = new Market
{
    Id = 1,
    Name = "Super Market",
    ProductTypeOnPromotion = ProductType.Electronics
};

User user1 = new User(1, "Bob Bobsky", "bobsky@mail.com", 30, ProductType.Electronics);
User user2 = new User(2, "John Doe", "johndoe@mail.com", 25, ProductType.Food);
User user3 = new User(3, "Alice Smith", "alicesmith@mail.com", 28, ProductType.Other);

market.SunscribeForPromotion(user1.ReadPromotion, user1.Email);
market.SunscribeForPromotion(user2.ReadPromotion, user2.Email);

market.SendPromotion();