// ✅ JAVASCRIPT PRACTICE TASKS
// 7️⃣ Sum Until Zero

// Goal: Continuously ask for numbers and stop when the user enters zero. Output the sum.

// Function: function sumUntilZero()

// Input:

//     Numbers ending with 0

// Output: Sum of entered numbers

// Test Cases:

//     Input: 5, 3, 2, 0 → Output: 10
//     Input: 1, 1, 1, 0 → Output: 3


function sumUntilZero(arr) {

    let sum = 0;

    let array = [];

    //for optional array param
    if (arr) {
        array = arr;

    } else { //else ask for inputs

        //infinite loop
        while (true) {
            let input = prompt("Enter a number (0 to stop):");
            input = parseInt(input);
            array.push(input);

            //stop if 0
            if (input === 0) {
                break;
            }
        }
    }

    for (let num of array) {
        if (num !== 0) {
            sum += num;
        }
    }

    console.log("Sum of entered numbers: ", sum);
}

//test cases
let arr1 = [5, 3, 2, 0];
sumUntilZero(arr1); // 10

let arr2 = [1, 1, 1, 0];
sumUntilZero(arr2); // 3