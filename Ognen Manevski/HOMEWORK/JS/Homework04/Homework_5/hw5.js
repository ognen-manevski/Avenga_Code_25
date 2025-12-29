// Homework #5
// Title: Looping structures

// Description: Write a JavaScript function that will return:
// The sum of the MAX and MIN numbers from an array with numbers
// Ex: arr = [3, 5, 6, 8, 11]
// Output: Max: 11, Min: 3, Sum: 14

// Bonus: Try making the function work if there are other types of items in it

let arr = [3, 5, "hello", 6, true, 8, 11, null, -4, undefined];

//od predhodnoto domashno
function validateNumber(num) {
    if (Number.isNaN(num) || typeof num !== 'number') {
        return false;
    }
    return true;
}

function sumOfMinAndMax(arr) {

    let min = Infinity;
    let max = -Infinity;

    for (let item of arr) {
        if (validateNumber(item)) {

            min = Math.min(min, item);
            max = Math.max(max, item);

            // if (item < min) {
            //     min = item;
            // }
            // if (item > max) {
            //     max = item;
            // }

        } else {

            console.log(`Warning: Skipping invalid number at index ${arr.indexOf(item)}`);
            continue;
        }
    }

    let sum = min + max;
    console.log(`Max: ${max}, Min: ${min}, Sum of Min and Max: ${sum}`);
}

sumOfMinAndMax(arr);