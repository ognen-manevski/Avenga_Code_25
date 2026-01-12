// ✅ JAVASCRIPT PRACTICE TASKS
// 5️⃣ Sum of Positive Numbers

// Goal: Store numbers in an array and calculate the sum of positive values.

// Function: function sumPositiveNumbers()

// Input:

//     Array of numbers

// Output: Sum of positive numbers

// Test Cases:

//     Input: [1, -2, 3, -4, 5] → Output: 9
//     Input: [-1, -2, -3] → Output: 0


function sumPositiveNumbers(array) {

    let sum = 0;

    for (let num of array) {
        if (num > 0) {
            sum += num;
        }
    }
    return sum;
}

//test cases
let testArray1 = [1, -2, 3, -4, 5];
console.log(sumPositiveNumbers(testArray1)); // 9

let testArray2 = [-1, -2, -3];
console.log(sumPositiveNumbers(testArray2)); // 0