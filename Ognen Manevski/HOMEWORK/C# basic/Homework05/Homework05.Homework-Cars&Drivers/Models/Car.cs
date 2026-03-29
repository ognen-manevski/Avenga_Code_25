namespace Homework05.Homework_Cars_Drivers.Models
{
    public class Car
    {
        //props
        public string Model { get; set; }
        public double SpeedMultiplier { get; set; }
        //public Driver Driver { get; set; }


        //constructor
        public Car(string model, double speedMultiplier)
        {
            Model = model;
            SpeedMultiplier = speedMultiplier;
            //Driver = driver;
        }

        //methods
        public double CalculateSpeed(Driver Driver) 
        {
            //use driver param if provided
            //Driver DriverFinal = DriverParam ?? this.Driver;

            //error protection
            //if (DriverFinal == null) return 0; 

            return Driver.Skill * SpeedMultiplier;
        }


    }
}
