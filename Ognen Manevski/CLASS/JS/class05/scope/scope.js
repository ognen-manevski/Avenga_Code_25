// //Global scope
// function myFunc() {
//     //function scope
//     function myFunc1() {
//         //myFunc1 scope
//     }

//     if (expression) {
//         //if scope
//     }
// }


// //function scope example

// function simpleFunction() {
//     let number = 10;
//     console.log(number); //10
// }

// simpleFunction();
// // console.log(number); //ReferenceError: number is not defined


// //global scope

// let str = "some string";

// function simpleFunc1() {
//     let str = "some OTHER string";
//     console.log(str); //some OTHER string
// }

// simpleFunc1();
// console.log(str); //some string

// let globalVar = 500;

// function simpleFunc2() {
//     globalVar = 600; //modifying global variable
//     console.log(globalVar); //600
// }

// simpleFunc2();
// console.log(globalVar); //600

// //

// let num = 5;
// let isEven;

// if (num % 2 === 0) {
//     isEven = true;
// } else {
//     isEven = false;
// }

// function simpleFnc3() {
//     a = 50; //implicit global variable
// }

// simpleFnc3();
// console.log(a); //50 (var a = 50;)

// let message = "Outside the function";
// function warning(message) {
//     console.log(message);
// }
// warning("Inside the function"); //Inside the function
// console.log(message); //Outside the function

// //

// let global = 1234;

// function simpleFunction4() {
//     console.log("first scope", global); //1234  
//     function simpleFunction5() {
//         console.log("second scope", global); //1234 
//         if (global === 1234) {
//             console.log("if scope", global); //1234 
//             global = 4321;
//             console.log("after value change", global); //4321 
//         }
//     }
//     simpleFunction5();
// }
// simpleFunction4();


// function cToF(celsius) {
//     let fahrenheit = (celsius * 1.8) + 32;
//     console.log(fahrenheit);
// }

// function fToC(fahrenheit) {
//     let celsius = (5 / 9) * (fahrenheit - 32);
//     console.log(celsius);
// }

// cToF(30);
// fToC(86);


// function calculateAge(birthYear, currentYear) {
//     let date = new Date();
//     let currentYearNow = date.getFullYear();
//     let currentYearUsed = currentYear || currentYearNow;
//     let age = currentYearUsed - birthYear;
//     console.log("You are " + age + " years old");
// }

// calculateAge(1990, 2025);
// calculateAge(2000, 2025);
// calculateAge(1985, 2025);

// function calculateAge(birthYear, currentYear = new Date().getFullYear()) {
//     let age = currentYear - birthYear;
//     console.log("You are " + age + " years old");
// }

// calculateAge(2000, 2011);

