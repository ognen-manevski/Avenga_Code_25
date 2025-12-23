// 🧮 Task 4: Simple Calculator
// Requirements

//     Ask the user to enter two numbers.
//     Ask the user to choose an operation (+, -, *, /).
//     Perform the chosen operation using control structures.
//     Display the result using concatenation, for example: "5 + 3 = 8"

// ⭐ Bonus (Invalid Input Handling)

//     If the user enters an invalid operation, display: "Invalid operation selected."
//     If the user tries to divide by zero, display: "Division by zero is not allowed."


// get user input
let input1 = prompt("Enter the first number:");
let num1 = parseFloat(input1);

let input2 = prompt("Enter the second number:");
let num2 = parseFloat(input2);

let operation = prompt("Choose an operation (+, -, *, /):");

let result;

// perform operation based on user choice

// +
if (operation === "+") {
    result = num1 + num2;
    console.log(num1 + " + " + num2 + " = " + result);

    // -
} else if (operation === "-") {
    result = num1 - num2;
    console.log(num1 + " - " + num2 + " = " + result);

    // *
} else if (operation === "*") {
    result = num1 * num2;
    console.log(num1 + " * " + num2 + " = " + result);

    // /
} else if (operation === "/") {

    // 0 check
    if (num2 === 0) {
        console.log("Division by zero is not allowed.");

    } else {
        result = num1 / num2;
        console.log(num1 + " / " + num2 + " = " + result);
    }

    // invalid operation
} else {
    console.log("Invalid operation selected.");
}