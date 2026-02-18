// Call Stack and Event Loop
// let first = () => console.log("I'm first");
// let second = () => console.log("I'm second");
// let third = () => console.log("I'm third");

//if we call these functions in this order,
//they will get executed in the exact same order
// first();
// second();
// third();

// first();
// setTimeout(second, 2000);
// third();

// console.log("=== Example 2 ===");
// first();
// setTimeout( function () {
//     console.log("I'm second");
// }, 0); //removes it from the stack
// third();

// console.log("=== Example 3 ===");
// first();
// setTimeout(() => {
//     console.log("I'm before second");
//     second();
// }, 2000);
// third();

// console.log("=== Example 4 ===");
// setTimeout(() => {
//     first();
//     setTimeout(() => {
//         second();
//     }, 20);    
// }, 30);
// third();

// Callbacks
// console.log("=== Callbacks ===");
// let sayHello = (personName) => console.log(`First Say Hello! Hello, ${personName}!`);
// let sayGoodbye = (personName) => console.log(`Goodbye, ${personName}!`);
// let greetSomeone = (callback, name) => {
//     setTimeout(() => {
//         console.log("Greet person first!");
//         callback(name);
//     }, 10)
// }
// greetSomeone(sayHello, "Alice");

// setTimeout(() => {
//     console.log("First");
//     setTimeout(() => {
//         console.log("Second");
//         setTimeout(() => {
//             console.log("Third");
//         }, 100)
//     }, 100)
// }, 100);

// const url = "https://raw.githubusercontent.com/sedc-codecademy/skwd9-04-ajs/main/Samples/students_v2.json";
// let dataFromApi = [];

// let getData = (url, callback) => {
//     fetch(url)
//     .then(response => response.json())
//     .then(data => {
//         dataFromApi = data;
//         console.log("the request succeded");
//         callback(dataFromApi);        
//         return dataFromApi;
//     })
//     .catch(err => console.error("Error fetching data:", err));
// }

// let printData = (data) => {
//     console.log(dataFromApi);
// }

// getData(url, printData);

// setTimeout(() => {
//     console.log(dataFromApi);
// }, 4);


// let first = (callback) => {
//     setTimeout(() => {
//         console.log("first thing");
//         callback();
//     }, 1000);
// }
// let second = () => console.log("second thing");

// first(second);

// let interval = setInterval(() => {
//     console.log("Hello!");
// }, 1000);

// document.getElementById("btn")
//     .addEventListener("click", () => {
//         clearInterval(interval);
//     });