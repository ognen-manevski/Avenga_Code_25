/*Class 6 Homework 📒 Practice LINQ Vol. 2 🏋️‍♂️*/
using Homework06.LINQ_Practice.Models;
using Homework06.LINQ_Practice.Data;
using Homework06.LINQ_Practice.Helpers;

//1. Filter all cars that have origin from Europe.
List<Car> carsFromEurope = CarsData.Cars
    .Where(c => c.Origin == "Europe")
    .ToList();
//carsFromEurope.PrintIterable("Cars from Europe");


//2.Find all unique cylinder values for cars.
List<int> uniqueCylinders = CarsData.Cars
    .Select(c => c.Cylinders)
    .Distinct()
    .ToList();
//uniqueCylinders.PrintIterable("All Unique Cylinders");


//3. Select all car names with their model names converted to uppercase.
List<string> uppercaseNames = CarsData.Cars
    .Select(c => c.Model.ToUpper())
    .ToList();
//uppercaseNames.PrintIterable("Car Models in Uppercase");


//4. Check if there are any cars with horsepower greater than 300.
bool any300Hp = CarsData.Cars
    .Any(c => c.HorsePower > 300);
//Console.WriteLine($"Are there any cars with more than 300Hp? {(any300Hp ? "Yes" : "No")}");

//5. Find the car with the highest horsepower.
Car? highestHpCar = CarsData.Cars
    .MaxBy(c => c.HorsePower);


//6. Filter all "Chevrolet" cars and order them by weight in descending order.
List<Car> chevroletCars = CarsData.Cars
    .Where(c => c.Model.Contains("Chevrolet")) //or StartsWith("Chevrolet")                  
    .OrderByDescending(c => c.Weight)
    .ToList();



//7. Find the car with the longest model name.
Car? longestName = CarsData.Cars
    .OrderByDescending(c => c.Model.Length)
    .FirstOrDefault();


//8. Group cars by their origin and then order the groups by the number of cars in each group, in ascending order.
IEnumerable<IGrouping<string, Car>> groupedCars = CarsData.Cars
    .GroupBy(c => c.Origin) //makes groups
    .OrderBy(g => g.Count()); //sort groups, ascending default
//PrintHelpers.PrintIterable(groupedCars, "Grouped cars");


//9. Find the first 5 cars with the highest horsepower.
//   (hint: read about LINQ methods Skip() and Take())
List<Car> first5Hp = CarsData.Cars
    .OrderByDescending(c => c.HorsePower)
    .Take(5)
    .ToList();



//10. Find the car with the highest acceleration time.
Car? highestAccelerationCar = CarsData.Cars
    .MaxBy(c => c.AccelerationTime); //MaxBy(); returns object


//11. Select only the model and horsepower of cars with horsepower greater than 200.
List<Car> moreThan200Hp = CarsData.Cars
    .Where(c => c.HorsePower > 200)
    .Select(c =>
    {
        return new Car { Model = c.Model, HorsePower = c.HorsePower }; //just Model and HorsePower 
    })
    .ToList();
// wrong^ we need t ocreate a new class for the objects
// CarInfo at end of file
List<CarInfo> moreThan200Hp2 = CarsData.Cars
    .Where(c => c.HorsePower > 200)
    .Select(c =>
    {
        return new CarInfo { Model = c.Model, HorsePower = c.HorsePower };
    })
    .ToList();
//even better with record type
//records are immutable, so we can only set values through constructor, no need for property setters
List<CarInfoRecord> moreThan200Hp3 = CarsData.Cars
    .Where(c => c.HorsePower > 200)
    .Select(c =>
    {
        return new CarInfoRecord(c.Model, c.HorsePower);
    })
    .ToList();




//12. Select all unique origins of cars, ordered alphabetically (ascending).
List<string> allOrigins = CarsData.Cars
    .Select(c => c.Origin)
    .Distinct()
    .OrderBy(origin => origin) //default for string is alphabetic
    .ToList();

//13. Select all cars with more than 4 cylinders, and order them by origin and then by horsepower.
List<Car> moreThan4Cylinders = CarsData.Cars
    .Where(c => c.Cylinders > 4)
    .OrderBy(c => c.Origin)
    .ThenBy(c => c.HorsePower)
    .ToList();




//14. Filter all cars that have more than 6 Cylinders not including 6
//after that Filter all cars that have exactly 4 Cylinders and have HorsePower more then 110.0.
//Join them in one result.
List<Car> customFilter14 = CarsData.Cars
    .Where(c =>
        (c.Cylinders > 6) ||                            //filter1
        (c.Cylinders == 4 && c.HorsePower > 110.0))     //filter2
    .ToList();

//with Union()
List<Car> moreThan6Cylinders = CarsData.Cars
    .Where(c => c.Cylinders > 6)
    .ToList();

List<Car> exactly4Cylinders = CarsData.Cars
    .Where(c => c.Cylinders == 4 && c.HorsePower > 110.0)
    .ToList();

List<Car> union14 = moreThan6Cylinders
    .Union(exactly4Cylinders) //removes duplicates
    .ToList();

//with Concat()
List<Car> concat14 = moreThan6Cylinders
    .Concat(exactly4Cylinders) //includes duplicates
    .ToList();


//15. Filter all cars that have more then 200 HorsePower
//and Find out how much is the lowest, highest and average Miles per galon for these cars.
List<Car> customFilter15 = CarsData.Cars
    .Where(c => c.HorsePower > 200)
    .ToList();

double lowestMpg = customFilter15.Min(c => c.MilesPerGalon);
double highestMpg = customFilter15.Max(c => c.MilesPerGalon);
double averageMpg = customFilter15.Average(c => c.MilesPerGalon);



//16. Custom 1
//Be creative and write requirement of your own choice :) (only one catch, must use at least 3 LINQ methods)
//Find all cars from USA with more than 150 HorsePower, order them by MilesPerGalon descending,
//and take the top 10 most fuel-efficient cars.
List<Car> custom16 = CarsData.Cars
    .Where(c => c.Origin == "US" && c.HorsePower > 150)
    .OrderByDescending(c => c.MilesPerGalon)
    .Take(10)
    .ToList();


//17. Custom 2
//Be creative and write requirement of your own choice :) (only one catch, must use at least 3 LINQ methods)
//Find all European cars, select only their model names, order them alphabetically, and skip the first 5 results.
List<string> custom17 = CarsData.Cars
    .Where(c => c.Origin == "Europe")
    .Select(c => c.Model)
    .OrderBy(model => model) //string
    .Skip(5)
    .ToList();


internal class CarInfo
{
    public string Model { get; set; }
    public double HorsePower { get; set; }
}

internal record CarInfoRecord(string Model, double HorsePower);
