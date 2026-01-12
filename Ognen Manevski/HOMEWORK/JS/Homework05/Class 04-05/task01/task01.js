// ✅ JAVASCRIPT PRACTICE TASKS
// 1️⃣ Average of Numbers

// Goal: Ask the user for how many numbers they want to enter, store them in an array, and calculate the average.

// Function: function calculateAverage()

// Input:

//     Number count
//     Numbers

// Output: Average value

// Test Cases:

//     Input: 3, 10, 20, 30 → Output: 20
//     Input: 4, 5, 5, 5, 5 → Output: 5


let count = prompt("Enter the number of values you want to input:");
count = parseInt(count);

let numbers = [];

for (let i = 0; i < count; i++) {
    let num = prompt(`Enter number (${i + 1}):`);
    num = parseInt(num);

    if (isNaN(num)) {
        alert("Invalid input. Please enter a valid number.");
        i--; //retry for same index
        continue;
    }

    numbers.push(num);
}

function calculateAverage(array) {

    let sum = 0;

    for (let num of array) {
        sum += num;
    }

    let average = sum / array.length;
    console.log("Average:", average);
}

calculateAverage(numbers);

//test:

let array1 = [10, 20, 30];
calculateAverage(array1);

let array2 = [5, 5, 5, 5];
calculateAverage(array2);









