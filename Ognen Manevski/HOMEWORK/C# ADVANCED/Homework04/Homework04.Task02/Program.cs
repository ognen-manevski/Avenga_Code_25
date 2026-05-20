/*
 Task 2

    Create a class Vehicle that has one method DisplayInfo().
    Create class Car, MotorBike, Boat, Airplane that will inherit from Vehicle and will implement the respective method.
*/

using Homework04.Task02.Models;
using Homework04.Task02.Models.BaseEntity;

Vehicle car = new Car();
Vehicle motorBike = new MotorBike();
Vehicle boat = new Boat();
Vehicle plane = new Plane();

car.DisplayInfo();
motorBike.DisplayInfo();
boat.DisplayInfo();
plane.DisplayInfo();