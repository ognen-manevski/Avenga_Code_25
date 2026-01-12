// ✅ JAVASCRIPT PRACTICE TASKS
// 1️⃣4️⃣ Sum of Digits

// Goal: Calculate the sum of all digits in a number.

// Function: function sumOfDigits()

// Input:

//     Number

// Output: Sum of digits

// Test Cases:

//     Input: 345 → Output: 12
//     Input: 1001 → Output: 2



function sumOfDigits(number) {

    let sum = 0;

    //reusing code from previous task
    while (number > 0) {
        let digit = number % 10;
        sum += digit;
        number = Math.floor(number / 10);
    }

    return sum;
}


//using toString() method
function sumOfDigitsV2(number) {
    let sum = 0;
    let numStr = number.toString();
    for (let i = 0; i < numStr.length; i++) {
        sum += parseInt(numStr[i]);
    }
    return sum;
}


//test cases
console.log(sumOfDigits(345));   // Output: 12
console.log(sumOfDigits(1001));  // Output: 2