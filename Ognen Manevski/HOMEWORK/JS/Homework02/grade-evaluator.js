// Task 5: Grade Evaluator
// Requirements

//     Ask the user to enter a score between 0 and 100.

//     Convert the input to a number using parseInt().

//     Determine the grade:
//         90–100: "A"
//         80–89: "B"
//         70–79: "C"
//         60–69: "D"
//         Below 60: "F"

//     Display a message like: "Your score is 85 and your grade is B."

// ⭐ Bonus (Invalid Input Handling)

//     If the score is less than 0, greater than 100, or not a number, display:
//     "Please enter a valid score between 0 and 100."


// get user input
let input = prompt("Enter your score (0-100):");

let score = parseInt(input);

// validate input
if (!Number.isNaN(score) && score >= 0 && score <= 100) {
    let grade;

    if (score >= 90) {
        grade = "A";
    } else if (score >= 80) {
        grade = "B";
    } else if (score >= 70) {
        grade = "C";
    } else if (score >= 60) {
        grade = "D";
    } else {
        grade = "F";
    }

    console.log(`Your score is ${score} and your grade is ${grade}.`);


} else {
    console.log("Please enter a valid score between 0 and 100.");
}

