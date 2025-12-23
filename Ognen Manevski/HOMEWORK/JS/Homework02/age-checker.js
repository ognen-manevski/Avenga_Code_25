// 🧒 Task 1: Age Checker
// Requirements
//     Ask the user to enter their age using prompt().

//     Convert the input to a number using parseInt().

//     Check:
//         If the age is less than 13, display: "You are a child."
//         If the age is between 13 and 17, display: "You are a teenager."
//         If the age is 18 or older, display: "You are an adult."

//     Display the message using string concatenation.

// ⭐ Bonus (Invalid Input Handling)

//     If the user enters a value that is not a number or a negative number, display: "Please enter a valid age."


//getting user input
let input = prompt("Please enter your age:");

let age = parseInt(input);

if (!Number.isNaN(age) && age >= 0) {

    if (age < 13) {
        console.log("You are a child.");
    } else if (age >= 13 && age <= 17) {
        console.log("You are a teenager.");
    } else {
        console.log("You are an adult.");
    }

} else {
    console.log("Please enter a valid age.");
}