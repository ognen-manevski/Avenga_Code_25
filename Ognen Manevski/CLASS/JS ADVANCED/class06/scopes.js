//global scope
//the name variable lives (it is declared) in the global scope)
let username = "Ognen";
function printName(username) {
    //the input parameter name belongs to the
    //block (function) scope of the printName() function
    console.log(username);
}
// printName("John");
let displayInConsole = () => {
    let message = "Hello there and welcome!";
    username = "Jane";
    console.log(`${message} ${username}`);
}
message = "New Message";
// displayInConsole();
let sayHello = () => {
    username = "Marko";
    console.log(`Hello there ${username}`);
}
let sayGoodbye = () => {
    console.log(`Goodbye ${username}`);
}
// sayHello();
// sayGoodbye();
function first() {
    let number = 10;
    return function second() {
        let positiveNum = 20;
        return function third() {
            let negativeNum = -10;
            console.log( username, positiveNum, negativeNum, number);
        }
    }
}
// first();
var x = 20;
console.log(x);
x = 40;
var x = 35;
console.log(x);
y = 120;
console.log(y);
let firstName = "Ognen 2";
console.warn(firstName);
console.error
console.assert();
console.log();

