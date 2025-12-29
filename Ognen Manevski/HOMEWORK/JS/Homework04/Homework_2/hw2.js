// HOMEWORK #2
// Write a function that will take an array of 5 numbers as an argument and return the sum.

// Print it in the console or in alert

// BONUS: Write another function called validateNumber() that checks if a number is a valid number
//  and call it for every number.
// If one of the numbers of the array is invalid show an error message instead of a result.

let arr = [1, 34, 69, 67, 78];

function validateNumber(num) {
    if (Number.isNaN(num) || typeof num !== 'number') {
        return false;
    }
    return true;
}

function sumOfArray(arr) {
    let sum = 0;
    for (num of arr) {
        if (validateNumber(num)) {
            sum += num;
        } else {
            console.log(`Error: Invalid number at index ${arr.indexOf(num)} in the array`);
            return;
            // ako sakame da prodolzhi namesto da prekine
            // console.log(`Warning: Skipping invalid number at index ${arr.indexOf(num)} in the array`);
            // continue;
        }
    }
    console.log(sum);
}

sumOfArray(arr);

