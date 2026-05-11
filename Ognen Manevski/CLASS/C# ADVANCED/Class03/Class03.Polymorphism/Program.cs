//=======================================================
#region runtime polymorphism
//=======================================================

using Class03.Polymorphism.Models;
using Class03.Polymorphism.Services;

Pet randomPet = new Pet()
{
    Name = "Generic Pet"

};
randomPet.Eat();

Cat zuza = new Cat()
{
    Name = "Zuza",
    IsLazy = true
};
zuza.Eat();


Dog aks = new Dog()
{
    Name = "Aks"
};
aks.Eat();


#endregion
//=======================================================

Console.WriteLine(new string('-', 20));

//=======================================================
#region compiletime polymorphism / method overloading
//=======================================================

PetService petService = new PetService();

petService.PrintPetInfo();
petService.PrintPetInfo(zuza);
petService.PrintPetInfo(aks);
petService.PrintPetInfo("John", aks);
//petService.PrintPetInfo("John", zuza); //not allowed - no method with this signature




#endregion
//=======================================================