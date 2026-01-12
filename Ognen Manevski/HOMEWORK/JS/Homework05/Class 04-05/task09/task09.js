// ✅ JAVASCRIPT PRACTICE TASKS
// 9️⃣ Count Digits

// Goal: Determine how many digits a number contains.

// Function: function countDigits()

// Input:

//     Number

// Output: Digit count

// Test Cases:

//     Input: 1234 → Output: 4
//     Input: 7 → Output: 1


//from class
function countDigits1(num) {

    number = Math.abs(num); //handle negative numbers

    let digitCount = 1; //num must have atleast 1 digit

    while (number > 9) {
        digitCount++;
        number = Math.floor(number / 10);
    }

    console.log(`The number ${num} has ${digitCount} digit(s).`);

}


//copilot suggested
function countDigits2(num) {
    //convert to string and get length
    let digitCount = Math.abs(num).toString().length;
    console.log(`The number ${num} has ${digitCount} digit(s).`);
}

//test cases
countDigits1(1234); // 4
countDigits1(7); // 1
countDigits1(0); // 1
countDigits1(-456); // 3

countDigits2(1234); // 4
countDigits2(7); // 1
countDigits2(0); // 1
countDigits2(-456); // 3