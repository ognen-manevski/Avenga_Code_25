// while (expression) { //expression should return false at some point
//     // code block to be executed
// }


// let counter = 0;

// while (counter <= 10) {
//     console.log('Counter value is: ', counter);
//     counter = counter + 1; // counter++
// }

// let daysOfWeek = [
//     "Monday",
//     "Tuesday",
//     "Wednesday",
//     "Thursday",
//     "Friday",
//     "Saturday",
//     "Sunday"
// ];


// let index = 0;

// while (index < daysOfWeek.length) {
//     console.log('Today is: ', daysOfWeek[index]);
//     index++;
// }

// let elements = [];

// let i = 0;

// while (i < 3) {
//     let input = prompt('Vnesi broj: ');
//     let parsedInput = parseInt(input);
//     elements.push(parsedInput);
//     i++;
// }

// console.log('Elements: ', elements);

// let largest = -Infinity;

// let counter = 0;

// while (counter < elements.length) {
//     let element = elements[counter];
//     if (element > largest) {
//         largest = element;
//     }
//     counter++;
// }

// console.log('Largest element is: ', largest);

// let numbers = [];

// let i = 101;

// while (i <= 150) {
//     numbers.push(i);
//     i++
// }

// let j = 0;

// let sum = 0;


// while (j < numbers.length) {
//     let current = numbers[j];
//     sum += Math.pow(current, 2);
//     j++;
// }

// console.log('Sum of squares is: ', sum);


// let i = 101;
// let sum = 0;
// while (i <= 150) {
//     sum += Math.pow(i, 2);
//     i++
// }

// console.log('Sum of squares is: ', sum);


// function digitsInNumber(number) {
//     while ((Math.floor(number) / 10) !== 0) {
//         let digit = number % 10;
//         console.log(digit);
//         number = Math.floor(number / 10);
//     }
// }

// digitsInNumber(123456789);


//do while

// do {
//     // code block to be executed
// } while (expression); //expression should return false at some point

// let i = 0;

// do {
//     console.log("running w/o check");
// } while (i !== 0);

// while (i !== 0) {
//     console.log("running with check");
// }


//for loops
//mora so brojach  / kaj while mozhe bilo kakov expression

let i = 0; // init of counter
while (i < 10) { //condition
    //code block
    i++;
}


//init of counter; condition; increment/decrement
for (let i = 0; i < 10; i++) { //we can use i again here bcz for makes a new scope
    console.log(i);
}

for (let i = 0; i < daysOfWeek.length; i++) {
    let element = daysOfWeek[i];
    console.log(element);
}




