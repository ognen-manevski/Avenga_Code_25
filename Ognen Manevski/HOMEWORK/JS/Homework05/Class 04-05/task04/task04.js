// ✅ JAVASCRIPT PRACTICE TASKS
// 4️⃣ Reverse an Array

// Goal: Create an array and output a new array with reversed order.

// Function: function reverseArray()

// Input:

//     Array

// Output: Reversed array

// Test Cases:

//     Input: [1, 2, 3] → Output: [3, 2, 1]
//     Input: [5, 10] → Output: [10, 5]


function reverseArray(array) {

    let reversedArr = [];

    for (let i = array.length - 1; i >= 0; i--) {
        reversedArr.push(array[i]);
    }
    return reversedArr;
}

//test cases
let arr1 = [1, 2, 3];
console.log(reverseArray(arr1)); // [3, 2, 1]

let arr2 = [5, 10];
console.log(reverseArray(arr2)); // [10, 5]



