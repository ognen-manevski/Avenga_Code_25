// // quotes within strings 
// let string1 = 'He said: "JavaScript is awesome!"';


// let greeting = "hello" + " " + "from" + " " + "Avenga Academy";
// // console.log(greeting);

// let hello = "hello";
// let academy = "Avenga Academy";
// let greetings = hello + ' from ' + academy + '!';
// // console.log(greetings);


// let baseURL = 'https://openn-meteo.com';
// let forecastURL = '/v1/forecast';

// let cb1 = 'elevation';
// let cb2 = 'daily';
// let cb3 = 'latitude';
// let cb4 = 'longitude';

// let url = baseURL + forecastURL + '?' + cb1 + '=1500' + '&' + cb2 + cb3 + cb4;
// let url2 = baseURL + forecastURL + '?' + cb4 + '=52.52.48.85' + '&' + cb3;

// // console.log(url, url2);

// let url3 = `${baseURL}${forecastURL}?${cb1}=1500&${cb2}&${cb3}&${cb4}=true`;

// let first = 10;
// let second = 'example';

// let result = first + second;
// console.log('result: ' + typeof result + ' ' + result );

// let num1 = 10;
// let num2 = '12';
// let res = num1+num2;
// console.log(`result: ${typeof res} ${res}`);

// let msg = "its really \"nice\" to be a programmer";
// console.log(msg);

// let a = 2 /"test";
// console.log(a);

// let b = 10;
// let c = "ognen";
// result = b / c;

// console.log( 'result is:' + result);
// console.log( result == NaN);
// console.log( result === NaN);
// console.log( isNaN(result) );

// let text = "10";
// console.log( isNaN(text) );

// console.log(Number.isNaN(text));

// let e = Infinity;
// let f = -Infinity;

// true false , falsy, truthy
//logical operators

// and 

// console.log(true && true); // true
// console.log(true && false); // false
// console.log(false && (3 == 4)); // false

// console.log("cat" && "dog"); // dog
// console.log( false && "cat"); // ""


// let a = true && true && false && true;
// console.log(a); // false

// let b = false && true && true && true;

// or 

// console.log(true || true); //true
// console.log(false || true); // true
// console.log(false || (3 == 4)); // false
// console.log("cat" || "dog"); // cat
// console.log(false || "cat"); // cat
// console.log('' || false); // false

// not 

// console.log(!true);
// console.log(!false);
// console.log(!'cat');
// console.log(!'');

// let abc = ( 3 == 3);
// console.log(abc);

// equality 

// let c = 10;
// let d = '10';
// console.log(c == d);
// console.log(typeof c == 'number' && typeof d == 'number' && c == d);
// console.log(c === d);

// let a1 = 41;
// let a2 = '42';
// let a3 = '43';

// console.log(a1 < a2); // true
// console.log(a2 < a3); // true
// console.log(a2 > a3);

// let b1 = 42;
// let b2 = 'ognen';

// console.log(b1 < b2); // false
// console.log(b1 > b2); // false
// console.log(b1 == b2); // false

// control structures 

// let score = 101;

// if (score > 100) {
//     console.log('score is higher than 100');
// }

// let score2 = 100;

// if (score2 <= 80) {
//     console.log('score is lower than 80');
// } else {
//     console.log('score is higher than 80');
// }

// let score3 = 100;
// if (score3 === 100){
//     console.log('score is equal to 100');
// } else if (score3 > 100){
//     console.log('score is higher than 100');
// } else {
//     console.log('score is lower than 100');
// }

// friday cash 

// let fridayCash = 10;
// // debugger;

// if (fridayCash >= 50) {
//     console.log('iyou should go to a dinner and a movie');
// } else if (fridayCash >= 35) {
//     console.log('you should go to a nice dinner');
// } else if (fridayCash >= 12) {
//     console.log('you should go see a movie');
// } else {
//     console.log('you should stay home');
// }

// getting an imput 

// let userInput = prompt('Enter a number: '); //string ALWAYS

// // console.log (userInput, typeof userInput);

// // let numberInput = Number(userInput);

// let parsedInput = parseInt(userInput);
// // parseFloat(userInput);

// // console.log (parsedInput, typeof parsedInput);

// if (!Number.isNaN(parsedInput)) {
//     if (parsedInput % 2 === 0) {
//         console.log('The number is even');
//     } else {
//         console.log('The number is odd');
//     }
// } else {
//     console.log('pls enter valid number');
// }

// exercise 1 

// let userAnswer = prompt("How much mney do you have?");

// let userCash = parseInt(userAnswer);

// if (userAnswer && !Number.isNaN(userCash)) {

//     //let userCash = parseInt(userAnswer);

//     //if (!Number.isNaN(userCash)) {

//     if (userCash >= 100) {
//         console.log('You can buy a new car');
//     } else if (userCash >= 50) {
//         console.log('You can buy a new phone');
//     } else if (userCash >= 20) {
//         console.log('You can buy popcorn');
//     } else {
//         console.log('You cannot buy anything');
//     }

//     // } else {
//     //     console.log('pls enter valid number');
//     // }

// } else {
//     console.log('null');
// }



// professor 
let input = prompt("How much money do you have?");

if (!input) {
    console.log('User cancelled the prompt.');
} else {
    let parsedInput = parseInt(input);

    if (Number.isNaN(parsedInput)) {
        console.log('Please enter a valid number.');
    } else {
        if (parsedInput >= 100) {
            console.log('You can buy a new car.');
        } else if (parsedInput >= 50) {
            console.log('You can buy a new phone.');
        } else if (parsedInput >= 20) {
            console.log('You can buy popcorn.');
        } else {
            console.log('You cannot buy anything.');
        }
    }
}   