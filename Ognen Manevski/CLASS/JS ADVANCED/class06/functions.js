//functions in js are also known as first class citizens
// 1. can be stored in a variable
let sayHello = function (name) {
    console.log(`Hello there ${name}`);

}
// sayHello("Bob");

// 2. can be stored in an array
let numbersStatFunctions = [
    (num) => num > 0 ? "Positive" : "Negative",
    (num) => num % 2 === 0 ? "Even" : "Odd",
    (num) => num > 0 ? num.toString().length : (num).toString().length - 1,
];
// console.log(
//     numbersStatFunctions[0](5),
//     numbersStatFunctions[1](5),
//     numbersStatFunctions[2](5),
// );

// 3. used as an arguemnt to another fn
function calculator(n1, n2, calculateFn) {
    return calculateFn(n1, n2);
}

function sum(n1, n2) {
    return n1 + n2;
}

function diff(n1, n2) {
    return n1 - n2;
}

// console.log(
//     calculator(2, 6, sum) + " , " +
//     calculator(2, 6, diff) + " , " +
//     calculator(15, 128, function (first, second) {
//         return first * second;
//     }) + " , " +
//     calculator(15, 128, (first, second) => first / second)
// );


// 4. used as return value from another fn
function calculate(operator) {
    switch (operator) {
        case "+": return (n1, n2) => n1 + n2;
        case "-": return (n1, n2) => n1 - n2;
        case "*": return (n1, n2) => n1 * n2;
        case "/": return (n1, n2) => n1 / n2;
        default: break;
    }
}
// console.log(calculate("*")(15, 18));


// 5. can have properties like a regular object
// 6. can have methods like a regular object
function sayGoodbye(name) {
    return `Goodbye there ${name}`;
}
sayGoodbye.defaultName = "Bob";
// console.log(sayGoodbye(sayGoodbye.defaultName));
sayGoodbye.differenGreeting = function (name) {
    return `Bye-bye ${name}`;
}
// console.log(sayGoodbye.differenGreeting("Martin"));


//

function print() {
    //"arguments" is a default param
    console.log(arguments[0]);
    console.log(arguments[1]);
};

// print("martin", "bob", "john");

function myCustomLog() {
    let result = "";
    for (arg of arguments) {
        result += arg + " ";
    }
    result = result.trim();
    console.log(result);
}
// myCustomLog(true, false, 2, 32, "Hello", "World", "!");


//higher order functions
// 1. forEach
let arr = [22, 30, 1, 5, 6, 0, -12, -24, -4, 15, 18];
// arr.forEach(function (element) {
//     console.log(element);
// });
// arr.forEach(element => console.log(element));

// 2. filter
let positiveNums = [];
for (el of arr) {
    if (el > 0) {
        positiveNums.push(el);
    }
}
// console.log(positiveNums);

let positives = arr.filter(el => el > 0);
// ^
// let positives = arr.filter(el => {
//     return el > 0
// });

// 3. map
let arrPlus1 = arr.map(el => el + 1);

// 4. sort

let sortedByAsc = arr.sort((a, b) => a - b);
let sortedByDesc = arr.sort((a, b) => b - a);
// console.log(sortedByAsc);

let names = ["Martin", "Bob", "John", "Alice", "Jane", "A", "B", "C", "D", "E"];
let names2 = names.map(name => name);
let sortedNames = names.sort((a, b) => a.localeCompare(b));
//this a > b calls localeCompare under the hood for string comparrison 
let sortedNames2 = names.sort((a, b) => a > b ? 1 : -1);
console.log(sortedNames);
console.log(sortedNames2);
//reverse
console.log(sortedNames.reverse());

//arrays are reference types, so when we sort them, we change the original array, and not create a new one.


