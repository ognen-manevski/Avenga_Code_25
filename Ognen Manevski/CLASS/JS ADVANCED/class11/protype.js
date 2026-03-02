function Animal(name, color, age) {
    this.name = name;
    this.color = color;
    this.age = age;
    this.printInfo = function () {
        console.log(`I'm ${this.name} the animal, I'm ${this.color}, I'm ${this.age} y old.`);
    }
}

function EarthAnimal(name, color, age, numOfLegs) {
    // this.name = name;
    // this.color = color;
    // this.age = age;

    //Avoid setting values of properties for EarthAnimal like below or above,
    // do the setting like line 21
    // this.__proto__ = Object.create(new Animal(name, color, age));
    // better way (17)^ because it doesn't create a new object for every instance of EarthAnimal like on line 19.
    // this.__proto__ = new Animal(name, color, age);
    
    Object.setPrototypeOf(this, new Animal(name, color, age));

    this.numOfLegs = numOfLegs;
    this.walk = function () {
        console.log(`I'm walking with my ${this.numOfLegs} legs.`);
    }
}

// EarthAnimal.prototype = Object.create(new Animal());
// let dog = new EarthAnimal(4);
// dog.name = 'Sharko';
// dog.color = 'black';
// dog.age = 3;

//better way ^
let dog = new EarthAnimal('Sharko', 'black', 3, 4);

// dog.printInfo();
// dog.walk();
// console.log(dog);

//how the process of inheritance using prototype works
// 1. new EarthAnmimal
// 2. EarthAnimal constructor function is called
// 3. setPrototypeOf() a new Animal object to the current object (this)
// 4. the values are passed to the new Animal() constructor f.
// 5. Animal constructor f is called
// 6. Annimal object is built from the animal constructor f
// 7. The returned Animal object is set as prototype to the current object (this)
// 8 the current object (this // EarthAnimal) is created
// 9. EarthAnimal obj is returned rom the new EarthAnimal and stored in our dog variable


//is this optimal?
// No, it's not optimal because it creates a new Animal object for every instance of EarthAnimal, which can lead to unnecessary memory usage. A better approach would be to set the prototype of EarthAnimal to a single instance of Animal, so that all instances of EarthAnimal share the same prototype and properties/methods defined in the Animal constructor function. This can be done using Object.create() or by directly setting the prototype to a new instance of Animal without passing parameters.

//example?
// function EarthAnimal(name, color, age, numOfLegs) {
//     this.numOfLegs = numOfLegs;
//     this.walk = function () {
//         console.log(`I'm walking with my ${this.numOfLegs} legs.`);
//     }
// }
// EarthAnimal.prototype = Object.create(new Animal());
// can also be done like this
// EarthAnimal.prototype = new Animal();
// can i put this inside the constructor function? no, because it will create a new Animal object for every instance of EarthAnimal, which is not optimal. It should be set outside the constructor function to ensure that all instances of EarthAnimal share the same prototype and properties/methods defined in the Animal constructor function.


//exercise
//vodno zhivotno, has legs boolean, size, metoda swim

function WaterAnimal(name, color, age, hasLegs, size) {
    Object.setPrototypeOf(this, new Animal(name, color, age));
    //what does this do? ^ It sets the prototype of the current object (this) to a new instance of Animal with the given name, color, and age. This allows the WaterAnimal to inherit properties and methods from the Animal constructor function.

    this.hasLegs = hasLegs;
    this.size = size;
    this.swim = function () {
        console.log(`I'm a ${this.size} fish and I'm swimming with my ${this.hasLegs ? 'legs' : 'fins'}.`);
    }
}

let fish = new WaterAnimal('Nemo', 'orange', 1, false, 'small');
fish.printInfo();
fish.swim();
console.log(fish);

