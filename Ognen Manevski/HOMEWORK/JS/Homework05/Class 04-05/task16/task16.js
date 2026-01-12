// ✅ JAVASCRIPT PRACTICE TASKS
// 1️⃣6️⃣ Armstrong Number Check

// Goal: Check if a number is an Armstrong number.

// Function: function isArmstrong()

// Input:

//     Number

// Output: "Armstrong" or "Not Armstrong"

// Test Cases:

//     Input: 153 → Output: "Armstrong"
//     Input: 123 → Output: "Not Armstrong"


// An Armstrong number is:
// A number where the sum of its digits
// each raised to the power of the number of digits
//  equals the original number.

// 153 → 1³ + 5³ + 3³ = 1 + 125 + 27 = 153 ✅




//reusing number of digits function from task09.js
function countDigits(number) {
    let digitCount = Math.abs(number).toString().length;
    return digitCount;
}

//sum of digits raised to power
function sumOfDigits(number, numberOfDigits) {
    let sum = 0;
    for (let i = 0; i < numberOfDigits; i++) {
        let digit = number % 10;
        // sum += digit ^ numberOfDigits
        sum += Math.pow(digit, numberOfDigits);
        number = Math.floor(number / 10);
    }
    return sum;
}


function isArmstrong(number) {

    number = Math.abs(number);

    let numOfDigits = countDigits(number);

    let sum = sumOfDigits(number, numOfDigits);

    if (sum === number) {
        return "Armstrong";
    } else {
        return "Not Armstrong";
    }
}

// test cases
console.log(isArmstrong(153)); // Output: "Armstrong"
console.log(isArmstrong(123)); // Output: "Not Armstrong"
