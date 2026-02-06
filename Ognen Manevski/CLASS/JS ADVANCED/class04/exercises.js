//ex 1

let countDigits = num => Math.abs(num).toString().length;
// return num.toString().replace("-", "").length;


// let evenOrOdd = num => {
//     if (num % 2 === 0) {
//         return 'even';
//     }
//     return 'odd';
// }

let evenOrOdd = num => num % 2 === 0 ? 'even' : 'odd';

// let positiveOrNegative = num => {
//     if (num >= 0) {
//         return 'positive';
//     }
//     return 'negative';
// }

let positiveOrNegative = num => num >= 0 ? 'positive' : 'negative';

// let processNumber = num => {
//     console.log(`The number ${num} is:`);
//     console.log(countDigits(num) + ' digits long');
//     console.log(evenOrOdd(num));
//     console.log(positiveOrNegative(num));
// }

let processNumber = num => console.log(
`The number ${num} is:
${countDigits(num)} digits long
${evenOrOdd(num)}
${positiveOrNegative(num)}`
);

processNumber(-123);

//ex 2
