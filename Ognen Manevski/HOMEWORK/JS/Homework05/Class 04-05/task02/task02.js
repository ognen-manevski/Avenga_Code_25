// ✅ JAVASCRIPT PRACTICE TASKS
// 2️⃣ Count Even Numbers

// Goal: Store user input numbers in an array and count how many are even.

// Function: function countEvenNumbers()

// Input:

//     Array of numbers

// Output: Count of even numbers

// Test Cases:

//     Input: [1, 2, 3, 4, 6] → Output: 3
//     Input: [7, 9, 11] → Output: 0


let userArray = [];
let evenCount = 0;


//reusing code from task01
function getInputArray() {

    let length = prompt("Enter the number of values you want to input in the array:");
    length = parseInt(length);

    let array = [];

    for (let i = 0; i < length; i++) {
        let num = prompt(`Enter number (${i + 1}):`);
        num = parseInt(num);

        if (isNaN(num)) {
            alert("Invalid input. Please enter a valid number.");
            i--; //retry for same index
            continue;
        }

        array.push(num);
    }
    return array;
}


function countEvenNumbers(array) {

    let evenCount = 0;

    for (let num in array) {
        if (array[num] % 2 === 0) {
            evenCount++;
        }
    }

    return evenCount;
}

userArray = getInputArray();
evenCount = countEvenNumbers(userArray);

console.log("User Input Array:", userArray);
console.log("Count of Even Numbers in that array:", evenCount);


//custom examples

let exampleArray1 = [1, 2, 3, 4, 6];
console.log("User Input Array:", exampleArray1);
console.log("Count of Even Numbers in that array:", countEvenNumbers(exampleArray1));

//
let exampleArray2 = [7, 9, 11];
console.log("User Input Array:", exampleArray2);
console.log("Count of Even Numbers in that array:", countEvenNumbers(exampleArray2));
