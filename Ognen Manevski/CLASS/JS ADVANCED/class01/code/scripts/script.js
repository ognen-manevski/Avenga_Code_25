//1. arrays and loops
let randomArr = [1, 2, 3, "Martin", "Ivan", undefined, true, false, null, 42.5, NaN, {}, []];
// console.log(randomArr);

let names = ["Martin", "Mario", "Klementina", "Marko", "Ivana"];
let numbers = [1, 2, 3, 4];

// let counter = 0;
// while (counter < names.length) {
//     console.log(names[counter]);
//     counter++;
// }

// for (let i=0; i<numbers.length; i++) {
//     console.log(numbers[i]);
// }

//2. functions

function printArr(arr, name) {
    console.log(`Printing${name ? ' ' + name : ''} array items: \n`);
    for (item of arr) {
        console.log(item);
    }
};
// printArr(names, "Names");

function greetPerson() {
    let name = prompt("Enter your name: ");
    alert(`Hello There: ${name ? ' ' + name : 'Martin'}!`);
};
// greetPerson();

//3. objects

//object literal
let student = {
    firstName: "John",
    lastName: "Doe",
    birthYear: 2004,
    age: 22,
    subjects: ["HTML/CSS", "BJS", "AJS"],
    currentSubject: "AJS",
    printSubjects: function() {
        for(subject of this.subjects) {
            console.log(subject);
        }
    }
};
// console.log(student);
// console.log(student.printSubjects());

//by using the Object() constructor

let trainer = new Object();
trainer.firstName = "Martin";
trainer.lastName = "Panovski";
trainer.birthYear = 1993;
trainer.calculateAge = function() {
    let birthYear = this.birthYear;
    let currentYear = new Date().getFullYear();
    let age = currentYear - birthYear;
    return age;
};
// console.log(trainer);
// console.log(trainer.calculateAge());

//constructor function

function Academy(name, city, address, numberOfStudents){
    this.name = name;
    this.city = city;
    this.address = address;
    this.numberOfStudents = numberOfStudents;
    this.getNumberOfStudents = function(){
        return this.numberOfStudents;      
    }
    this.getLocation = function(nameOfCity){
        if(nameOfCity.toLowerCase() == this.city.toLowerCase()){
            console.log(`The location of this ${this.name} Academy is in ${this.city} on this address: ${this.address}`);            
        } else {
            console.log(`There is no ${this.name} Academy on this Location.`);
        }
    }
}

// let avenga = new Academy("Avenga", "Skopje", "Test Address 1", 150);
// let qinshift = new Academy("Qinshift", "Ohrid", "Test Address 2", 120);
// let sedc = new Academy("SEDC", "Nish", "Test Address 3", 150);
// console.log(avenga);
// console.log(avenga.getLocation("Ohrid"));
// console.log(qinshift.getLocation("Ohrid"));
// console.log(sedc.getLocation("Ohrid"));




