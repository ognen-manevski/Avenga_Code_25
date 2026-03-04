//classes and inheritance in JS

class Vehicle {
    constructor(id, model, yearOfProduction, price) {
        this.id = id;
        this.model = model;
        this.yearOfProduction = yearOfProduction;
        this.price = price;
    }

    displayInfo() {
        console.log(`${this.id}. ${this.model}, Year: ${this.yearOfProduction} | Price: ${this.price} EUR`);
    }

}

let ford = new Vehicle(1, 'Ford Focus', 2020, 25000);
let toyota = new Vehicle(2, 'Toyota Corolla', 2018, 18000);

// console.log(ford);
// console.log(toyota);

// ford.displayInfo();
// toyota.displayInfo();

class WheeledVehicle extends Vehicle {
    constructor(id, model, yearOfProduction, price, numberOfWheels, fuelType) {
        super(id, model, yearOfProduction, price); // super means the constructor of the parent class (Vehicle) 
        this.numberOfWheels = numberOfWheels;
        this.fuelType = fuelType;

        this.drive = function () {
            switch (this.fuelType) {
                case 'petrol':
                    console.log(`This car spends 10l/100km.`);
                    break;
                case 'diesel':
                    console.log(`This car spends 6l/100km.`);
                    break;
                case "gas":
                    console.log(`This car spends 3l/100km.`);
                    break;
                default:
                    console.log(`No info for consumption`);
                    break;
            }
        }
    }
}


let ford1 = new WheeledVehicle(1, 'Ford Focus', 2020, 25000, 4, 'petrol');
let toyota1 = new WheeledVehicle(2, 'Toyota Corolla', 2018, 18000, 4, 'diesel');

// console.log(ford1);
// console.log(toyota1);

// ford1.drive();
// toyota1.drive();

class MathOperations {
    constructor() {
        this.PI = 3.14;
    }

    static PI = 3.14;

    static sum(a, b) { return a + b; }

    static diff(a, b) { return a - b; }

    static multiply(a, b) { return a * b; }

    static divide(a, b) { return (b === 0) ? 'Cannot divide by zero' : a / b; }

    static areEqual(a, b) { return a === b; }
}

// console.log(MathOperations.prototype.sum(1, 2)); // test

let div = MathOperations.divide(20, 4);
let sum = MathOperations.sum(10, 10);
let calc = MathOperations.sum(10, 10) / MathOperations.multiply(2, 2);

// console.log(div, sum, calc);
// console.log(MathOperations.PI);
// console.log(MathOperations.sum(5, 10));

console.log(ford1 instanceof Vehicle);
console.log(ford instanceof MathOperations);
