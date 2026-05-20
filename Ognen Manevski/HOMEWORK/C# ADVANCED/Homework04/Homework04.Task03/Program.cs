/*
 Task 3
From the previous task get the implementation and DO NOT CHANGE the implementation of the classes.
Now we need to EXTEND the functionalities with a couple of methods:
    Car objects should have Drive() method;
    MotorBike should have Wheelie() method;
    Boat should have Sail() method;
    Airplane should have Fly() method; 
 */

using Homework04.Task02.Models;
using Homework04.Task03.ExtensionMethods;

Car car = new Car();
MotorBike motorBike = new MotorBike();
Boat boat = new Boat();
Plane plane = new Plane();

car.Drive();
motorBike.Wheelie();
boat.Sail();
plane.Fly();

