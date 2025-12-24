// //standard template 

// function greet() {
//     console.log("Hello G1!");
// }
// greet();

// //arrow function

// let greetArrow = () => {
//     console.log("Hello G1!");
// }
// greetArrow();

// //shorter arrow function
// () => console.log("Hello G2!")

// //IIFE - Immediately Invoked Function Expression
// (() => console.log("Hello G2!"))();

// //arguments

// // let message = "Hello G3!";

// function printMessage(message) {
//     console.log(message);
// }

// let input = prompt("enter your message: ");
// printMessage(input);


// function sum(num1, num2) {
//     let result = num1 + num2;
//     return result;
// }

// let a = 10;
// let b = 15;

// sum(a, b);

// function sumV3(num1, num2) {
//     let result = num1 + num2;
//     return result;
// }

// let result = sumV3(5, 10);
// console.log(result);

// function getFullName(firstName, lastName) {
//     if (firstName && lastName) {
//         return firstName + " " + lastName;
//     }
//     return "N/A";
// }

// let fullName = getFullName("Ognen", "Manevski");
// console.log(fullName);

// let fullName2 = getFullName("", "");
// console.log(fullName2);


// function getDayByNumber(day) {
//     switch (day) {
//         case 1:
//             return "Monday";  // namesto break
//         case 2:
//             return "Tuesday";
//         case 3:
//             return "Wednesday";
//         default:
//             return "Invalid day";
//     }
// }

function sum(n1, n2) {
    let result = n1 + n2;
    return result;
}

function substract(n1, n2) {
    let result = n1 - n2;
    return result;
}

function multiply(n1, n2) {
    let result = n1 * n2;
    return result;
}

function divide(n1, n2) {
    if (n2 === 0) {
        return "Error: Division by zero is not allowed.";
    }
    let result = n1 / n2;
    return result;
}

//parameter mismatch

// function calculateLoan(amount, months, interet, name) {
//     console.log(amount);
//     console.log(months);
//     console.log(interet);
//     console.log(name);
// }

// console.log(calculateLoan());

function logDataInConsole(data, type = "info") {
    console.log(`${type}: ${data}`);
}

function modulNumbers(n1, n2) {
    if (n2 === 0) {
        return "Error: Division by zero is not allowed.";
    }
    let result = n1 % n2;
    return result;
}

// logDataInConsole("This is an information message.", "1231231");

function calculator(n1, n2, operation = "+") {


    switch (operation) {
        case "+":
            return sum(n1, n2);
        case "-":
            return substract(n1, n2);
        case "*":
            return multiply(n1, n2);
        case "/":
            return divide(n1, n2);
        case "%":
            return modulNumbers(n1, n2);
        default:
            return "Error: Invalid operation.";
    }
}

// console.log(calculator());


function getNumberFromPrompt(msg) {

    let input = prompt(msg);
    let parsedInput = parseFloat(input);

    if (isValidNumber(parsedInput)) {
        return parsedInput;
    }
    return -Infinity;
}

function isValidNumber(num) {
    return !Number.isNaN(num);
}

let n1 = getNumberFromPrompt("Enter first number:");
let n2 = getNumberFromPrompt("Enter second number:");


function isValidOperator(op) {
    switch (op) {
        case "+":
        case "-":
        case "*":
        case "/":
        case "%":
            return true;

        default:
            return false;
    }
}

if (n1 && n2) {
    let operator = prompt("Enter operation (+, -, *, /):");

    if (isValidOperator(operator)) {
        let result = calculator(n1, n2, operator);
        logDataInConsole(result, "result");
    } else {
        console.log("Error: Invalid operator.");
    }
}