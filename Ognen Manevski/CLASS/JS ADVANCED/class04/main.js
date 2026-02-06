//functions in js
function sayHello() {
    console.log("Hello from my function");
}
// sayHello();

function sumTwoNumbers(a, b) {
    return a + b;
}
// sumTwoNumbers(5,10);

//anonymous functions
let diffTwoNumbers = function (a, b) {
    return a - b;
}
// diffTwoNumbers(10,20);

let multiply = function (a, b) {
    return a * b;
}

let division = function (a, b) {
    return a / b;
}

//arrow functions

let multiplyArrow = (a, b) => a * b;
let divisionArrow = (a, b) => a / b;
let sumofThreeArrow = (a, b, c) => a + b + c;
let diffOfThreeArrow = (a, b, c) => a - b - c;
let squareNumberArrow = a => a * a;

let convertCurrency = (currencyType, currencyValue) => {
    if (currencyType === "EUR") {
        return currencyValue / 61.5;
    }
    if (currencyType === "MKD") {
        return currencyValue * 61.5;
    }
}

let args = [2, 5];
sumTwoNumbers(
    multiply(...args),
    division(...args)
);

//self-invoking fns or IIFE (immediately invoked function expression)
//makes its own scope

(function (a, b) {
    console.log("The sum of a and b is: " + (a + b));
})(2, 5);

((a, b) => {
    console.log("This is an IIFE")
})(1, 2);

(() => console.log("This is an IIFE"))();

let array = [1, 2, 3, 4, (a, b) => a + b];
console.log(array[4](2, 5));

//recursion

function sumTo(n) {
    if (n === 0) {
        return 0;
    }
    return n + sumTo(n - 1);
}

console.log(sumTo(20));

let sumToArrow = n => n === 0 ? 0 : n + sumToArrow(n - 1);

console.log(sumToArrow(20));


