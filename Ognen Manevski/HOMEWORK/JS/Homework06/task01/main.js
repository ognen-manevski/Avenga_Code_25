//create an animal object with 2 props and 1 method:
//name, kind, speak(method)
//this method will take one parameter and print in the console a message eg. dog.speak("hey bro!!")
//will log in the console "Dog says hey bro!!"
//Bonus enter the values from prompt or from html inputs

function Animal(name, kind) {
    this.name = name;
    this.kind = kind;
    this.speak = function (message) {
        alert (`This ${this.kind} says ${message}`);
    }
}

document.getElementById("btn").addEventListener("click", start);

function start() {
    let name = prompt("Enter the animal's name:");
    let kind = prompt("Enter the animal's kind:");
    let message = prompt("Enter the message the animal will say:");

    let animal = new Animal(name, kind);
    animal.speak(message);
}