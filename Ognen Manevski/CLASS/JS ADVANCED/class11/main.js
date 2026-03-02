function Vehicle (id, name, serialNo, price) {
    this.id = id;
    this.name = name;
    this.serialNo = serialNo;
    this.price = price;
    this.printVehicle = function() {
        console.log(`${this.id}. ${this.name}, Ser.No: ${this.serialNo} | Price: ${this.price}`);
    }
}

let obj = {};
// console.log(obj);

let wheeledVehicle = Object.create(new Vehicle(1, 'Ford', '1234', 5000));
wheeledVehicle.numOfWheels = 4;
wheeledVehicle.drive = function() {
    console.log('Driving...');    
}
// console.log(wheeledVehicle);

let car = Object.create(wheeledVehicle);
//what does this do? ^ It creates a new object (car) that inherits from the wheeledVehicle object. This means that car will have access to all properties and methods of wheeledVehicle, as well as any properties and methods defined on the Vehicle prototype.
car.fuelTankCapacity = 50;
// car.drive();
// car.printVehicle();
// console.log(car);

let bike = Object.create(wheeledVehicle);
bike.id = 2;
bike.numOfWheels = 2;
bike.name = 'Specialized';
bike.serialNo = '112';
bike.price = 500;
// bike.drive();
// bike.printVehicle();
// console.log(bike);

let wheeledVehicle1 = new Vehicle(3, 'Seat', 112233, 10000);
// let wheeledVehicle2 = Object.create(wheeledVehicle1);
let wheeledVehicle2 = {};
wheeledVehicle2.__proto__ = new Vehicle(4, 'Yugo', 123334, 500);
console.log(wheeledVehicle1);
console.log(wheeledVehicle2);
