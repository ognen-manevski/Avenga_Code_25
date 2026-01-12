// ✅ JAVASCRIPT PRACTICE TASKS
// 1️⃣5️⃣ Palindrome Number Check

// Goal: Check whether a number is a palindrome.

// Function: function isPalindrome()

// Input:

//     Number

// Output: "Palindrome" or "Not Palindrome"

// Test Cases:

//     Input: 121 → Output: "Palindrome"
//     Input: 123 → Output: "Not Palindrome"


// A palindrome is:
// A number (or word) that reads the same forwards and backwards.


//from task11.js - reverse array function
function reverseNumber(number) {
    let num = Math.abs(number);
    let reversedNum = 0;
    while (num > 0) {
        let digit = num % 10;
        reversedNum = reversedNum * 10 + digit;
        num = Math.floor(num / 10);
    }
    return reversedNum;
}

function isPalindrome(number) {
    let num = Math.abs(number);
    let reversedNum = reverseNumber(num);

    if (num === reversedNum) {
        console.log("Palindrome");
    } else {
        console.log("Not Palindrome");
    }
}

// Test Cases
isPalindrome(121); // Output: "Palindrome"
isPalindrome(123); // Output: "Not Palindrome"
isPalindrome(-121); // Output: "Palindrome"
