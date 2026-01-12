// ✅ JAVASCRIPT PRACTICE TASKS
// 3️⃣ Find the Smallest Number

// Goal: Read numbers into an array and determine the smallest value.

// Function: function findSmallest()

// Input:

//     Array of numbers

// Output: Smallest number

// Test Cases:

//     Input: [4, 2, 9, 1] → Output: 1
//     Input: [10, 20, 30] → Output: 10


//reusing code for getting an input array
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


function findSmallest(array) {

    if (array.length === 0) {
        return null; // Handle empty arr
    }

    let smallest = array[0];

    for (let index in array) {
        if (array[index] < smallest) {
            smallest = array[index];
        }
    }

    return smallest;
}


//test user input 
let userInputArray = getInputArray();
let smallestNumber = findSmallest(userInputArray);
alert(`The smallest number in the array [${userInputArray}] is: ${smallestNumber}`);

//test cases
console.log(findSmallest([4, 2, 9, 1])); // 1
console.log(findSmallest([10, 20, 30])); // 10
