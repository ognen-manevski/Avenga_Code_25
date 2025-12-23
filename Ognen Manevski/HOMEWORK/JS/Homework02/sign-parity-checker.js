// 🔢 Task 2: Number Sign & Parity Checker
// Requirements

//     Ask the user to enter a number using prompt().

//     Convert the input into a number using parseInt().

//     Check:
//         If the number is positive, negative, or zero.
//         If the number is even or odd.

//     Display a message using string concatenation, for example: "The number -4 is negative and even."

// ⭐ Bonus (Invalid Input Handling)

//     If the user does not enter a valid number, display: "Invalid input. Please enter a number."

// Get user input
let userInput = prompt("Please enter a number:");

let number = parseInt(userInput);

if (!Number.isNaN(number)) {

    // checking for positive, negative, or zero.
    let sign;
    if (number > 0) {
        sign = "positive";
    } else if (number < 0) {
        sign = "negative";
    } else {
        sign = "zero";
    }

    // checking for even or odd.
    let parity;
    if (number % 2 === 0) {
        parity = "even";
    } else {
        parity = "odd";
    }

    //contatenating the message
    console.log("The number " + number + " is " + sign + " and " + parity + ".");

} else {
    console.log("Invalid input. Please enter a number.");
}