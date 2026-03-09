// import with node 
const funcs = require("./functons.js");


console.log("Hello from my script file");
let a = 10;
let b = 20;

let person = {
    fullName: "John Doe",
    age: 30,
    jobTitle: "Software Engineer"
}

let printPersonInfo = (person) => {
    console.log(`Full Name: ${person.fullName} | Age: ${person.age} | Job Title: ${person.jobTitle}`);
}

console.log(a);
console.log(b);
printPersonInfo(person);


funcs.sayHello("Alice");
funcs.sayGoodbye("Bob");
funcs.printInConsole("This is a message printed in the console!");
// funcs.printInConsole();