// ✅ JAVASCRIPT PRACTICE TASKS
// 1️⃣1️⃣ Reverse a Number

// Goal: Reverse the digits of a given number.

// Function: function reverseNumber()

// Input:

//     Number

// Output: Reversed number

// Test Cases:

//     Input: 1234 → Output: 4321
//     Input: 90 → Output: 9


function reverseNumber(number) {

    let num = Math.abs(number);

    let reversedNum = 0;

    while (num > 0) {

        let digit = num % 10; //get last digit (1234 % 10 = 4)

        reversedNum = reversedNum * 10 + digit; //add 1's to 10's etc (0 * 10 + 4 = 4; 4 * 10 + 3 = 43)

        num = Math.floor(num / 10); //remove last digit (1234/10 = 123.4 -> 123)
    }

    console.log(`The reversed number from ${number} is: ${reversedNum}`);
}


//using .toString
function reverseNumberV2(number) {

    let num = Math.abs(number);

    let numStr = num.toString();

    let reversedStr = "";

    for (let i = numStr.length - 1; i >= 0; i--) {
        reversedStr += numStr[i];
    }

    let reversedNum = parseInt(reversedStr);

    console.log(`The reversed number from ${number} is: ${reversedNum}`);
}



//test cases
let number1 = 1234;
reverseNumber(number1); // 4321 
reverseNumberV2(number1); // 4321 

let number2 = 90;
reverseNumber(number2); // 9
reverseNumberV2(number2); // 9

