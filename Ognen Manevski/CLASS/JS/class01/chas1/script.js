// // alert("hello world from g1");
// console.log("hello world from g1");

// // declare variable 

// let number;
// number = 10;
// let number1 = 20;
// console.log(number, number1);


// let a = 1;

// {
//     let a = 2;
//     console.log(a);
// }

// // string 

// let string = ":p";
// let string2 = "haha";

// // numbers

// let num1 = 10;
// let num2 = 12;

// // booleans 

// let isTrue = true;
// let isFalse = false;

// // undefined 

// // let undefined;
// let undefined2 = undefined;

// // null
// let empty = null;

// let b = "text";
// let typeOfVariable = typeof b;
// console.log(typeOfVariable);


// let var1 = 14;
// let var2 = 27;

// let sum = var1 + var2;
// console.log("The sum is: " + sum);

// let substract = var2 - var1;
// console.log("The substract is: " + substract);

// let multiply = var1 * var2;
// console.log("The multiply is: " + multiply);    

// let divide = var2 / var1;
// console.log("The divide is: " + divide);

// let modulus = var2 % var1;
// console.log("The modulus is: " + modulus);

// // increment

// var1++;
// console.log("The increment is: " + var1);

// // comparisson operators

// let firstNumber = 10;
// let secondNumber = 20;  

// console.log(firstNumber == secondNumber);
// console.log(firstNumber != secondNumber);
// console.log(firstNumber > secondNumber);

// let name1 = "Ognen";
// let name2 = "ognen";

// console.log(name1 != name2);



// // exercise conversion from feet to meters


// // 1 feet = 0.3048 meters

// // let meters;

// // let conversionRate = 0.3048;

// // function feetToMeters(feet) {
// //     meters  = feet * conversionRate;
// //     console.log(feet + " feet is equal to " + meters + " meters.");
// // }

// feetToMeters(10);

// let metersPerFeet = 0.3048;
// let feet = 100;
// let meters = feet * metersPerFeet;
// console.log(feet + " feet is equal to " + meters + " meters.");


//rectangle area

// let a = document.querySelector("#length").value;
// let b = document.querySelector("#width").value;
// let area = a*b;
// console.log(area);

// area of a circle 

// let pi = Math.PI;
// let r = 10;
// // let area = pi * r * r;
// let area = pi * Math.pow(r, 2);
// console.log(area);


// let str = "Hello World!";
// let number = 42;

// console.log( str + number);

// console.log ("avenga" + " " + "academy" +  " " + 2025);

// let backticks = `Avenga Academy ${2025}`;
// console.log(backticks);

let url = "https://google.com/";

let ulWithParams = url + '/search' + '?' + 'id=' + '3' + '&' + 'name=ognen';

let a = 3;
let b = "ognen";
let urlWithBackticks = `${url}/search?id=${a}&name=${b}`;
