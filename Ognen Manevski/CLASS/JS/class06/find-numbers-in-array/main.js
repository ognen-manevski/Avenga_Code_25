
// function FindNumber(number, arr) {

//     let counter = 0;

//     for (let i = 0; i < arr.length; i++) {
//         if (arr[i] === number) {
//             counter++;
//         }
//     }
//     console.log(`There are ${counter} occurences of number "${number}" in the array.`);
// }

// let arr1 = [1, 2, 3, 4, 5, 3, 6, 3];
// let arr2 = [1, 2, 3, 4, 5, 6];
// let arr3 = [0, 0, 0, 1, 2, 3];

// FindNumber(3, arr1);
// FindNumber(7, arr2);
// FindNumber(0, arr3);


// function findOddOrEven(arr, type) {

//     let evenNumbers = [];
//     let oddNumbers = [];

//     if (type === 'even') {
//         for (let num in arr) {
//             if (arr[num] % 2 === 0) {
//                 evenNumbers.push(arr[num]);
//             }
//         }
//         console.log(`Even numbers in the array: ${evenNumbers}`);

//     } else if (type === 'odd') {
//         for (let num in arr) {
//             if (arr[num] % 2 !== 0) {
//                 oddNumbers.push(arr[num]);
//             }
//         }
//         console.log(`Odd numbers in the array: ${oddNumbers}`);

//     } else {
//         console.log('Type must be "even" or "odd".');
//     }
// }


function findOddOrEven(arr, type) {

    let result = [];

    if (type === 'odd') {
        for (let num in arr) {
            if (arr[num] % 2 !== 0) {
                result.push(arr[num]);
            }
        }
        console.log(`Odd numbers in the array: ${result}`);

    } else if (type === 'even') {
        for (let num in arr) {
            if (arr[num] % 2 === 0) {
                result.push(arr[num]);
            }
        }
        console.log(`Even numbers in the array: ${result}`);

    } else {
        console.log('Type must be "even" or "odd".');
    }
}


let arr1 = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
let arr2 = [11, 22, 33, 44, 55, 66, 77, 88, 99, 100];

findOddOrEven(arr1, 'even');
findOddOrEven(arr1, 'odd');
findOddOrEven(arr2, 'even');
findOddOrEven(arr2, 'odd');
findOddOrEven(arr2, '123');