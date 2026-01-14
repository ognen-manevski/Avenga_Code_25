//obj literal
let obj = {
    name: "Quay",
    rooms: 40,
    booked: 25,
    gym: true,
    roomTypes: ["twin", "double", "suite"],
    checkAvailability: function () {
        return this.rooms - this.booked;
    }
};

// console.log(obj);

//instancing 
let obj2 = new Object();

obj2.name = "Quay2";
obj2.rooms = 50;
obj2.booked = 40;
obj2.gym = false;
obj2.roomTypes = ["single", "double", 'suite', 'residential'];
obj2.checkAvailability = function () {
    return this.rooms - this.booked;
};

// console.log(obj2);

//get value:
//dot notation 
let a = obj.name;
//bracket notation
let aa = obj['name'];

// console.log(a);
// console.log(aa);

// set value 
obj.booked = 40;
obj2['booked'] = 40;

console.log(obj.checkAvailability()); //dot notation function call
console.log(obj2["checkAvailability"]()); //bracket notation function call


// exercise1

let me = {
    name: 'Ognen',
    surname: 'Manevski',
    age: 30,
    student: true,
    studies: ['HTML', 'CSS', 'JavaScript'],
    introduce: function () {
        if (this.student) {
            return `Hello, my name is ${this.name} ${this.surname}, I am ${this.age} years old.`;
        }
    }
};

//deleting property

delete obj.gym;
console.log(obj);
obj.hasGym = false;


//exercise2
//update the values of the object to represent someone else

me.name = 'John';
me.surname = 'Doe';
me.age = 25;
me.student = false;
me.studies = ['Python', 'Django'];
me.studies.push('Machine Learning');


//ex3

let trainer = {
    name: 'stefan',
    lastName: 'stefanovski',
    academy: 'SEDC',
    lecture: 'objects',
};

delete trainer.lecture;

trainer.getFullName = function () {
    return `${this.name} ${this.lastName}`;
};

//constructor function

function Hotel(name, rooms, booked) {
    this.name = name;
    this.rooms = rooms;
    this.booked = booked;
    this.hasGym = false;
    this.checkAvailability = function () {
        return this.rooms - this.booked;
    };
};

let holidayInn = new Hotel('Holiday Inn', 120, 110);
let mariott = new Hotel('Mariott', 200, 150);

//this

function checkThis() {
    console.log(this);
}
checkThis(); //in this case this refers to the global object (window in browser)

let shape = {
    type: 'circle',
    width: 20,
    height: 40,
    checkThisInObject: checkThis,
    // checkThisInObject: function () {
    //     console.log(this);
    // }
    //same shi
};

shape.checkThisInObject(); //in this case this refers to the object 'shape'

var width = 600; //global scope
let letWidth = 800; //block scope

let shape1 = {
    width: 400,
};

function showWidth(w) {
    console.log(this.width);
}

showWidth(); //600 wont work in strict mode
shape1.showWidthInObject = showWidth;
shape1.showWidthInObject(); //400


window.newShowWidth = showWidth;
window.newShowWidth(); //600

//ex4

function Car(model, color, year, fuel, fuelConsumption) {
    this.model = model;
    this.color = color;
    this.year = year;
    this.fuel = fuel;
    this.fuelConsumption = fuelConsumption; //liters per 100km
    //how much fuel for distance
    this.calculateFuel = function (distance) {
        let neededFuel;
        neededFuel = distance * this.fuelConsumption / 100;
        //distance / 100 -> how many 100km are in the distance
        return neededFuel;
        // return `${this.model} needs ${neededFuel} liters of fuel to cover ${distance} km.`;
    };
};

let audi = new Car('Audi A6', 'black', 2020, 50, 8);
let bmw = new Car('BMW X5', 'white', 2019, 60, 10);
let ww = new Car('VW Passat', 'blue', 2018, 55, 7);

console.log(audi.calculateFuel(200)); //16
console.log(bmw.calculateFuel(200)); //20
console.log(ww.calculateFuel(200)); //14


