// function greet() {
//     alert("Hello World!");
// }

// function countRabbits() {
//     for (let i = 1; i <= 3; i++) {
//         console.log("Rabbit No." + i);
//     }
// }

// let btn1 = document.getElementById("btn1");

// // btn1.onclick = greet;

// btn1.onclick = function () {
//     alert("Hello World from anonymous function!");
// }

// // btn1.onclick = () => {
// //     alert("Hello World from arrow function!");
// // }

// btn1.onmouseover = sayHello;

// function sayHello() {
//     alert("Hello from mouse over!");
// }

// //event listener  

// let btn2 = document.getElementById("btn2");

// // btn2.addEventListener("click", greet);
// btn2.addEventListener("click", function () {
//     alert("Hello from event listener!");
// });

let input = document.getElementById("input1");

let result = document.getElementById("result");

let history = [];

input.addEventListener("keypress", function (e) {
    // console.log("Input changed to: " + input.value);
    // console.log(e);
    let value = e.target.value;
    result.innerText = "You typed: " + value;

    if (e.keyCode === 13) {
        history.push(value);
        console.log("History: ", history);
    }

});

let btn3 = document.getElementById("btn3");


// function removeListener() {
//     console.log("clicked");
//     btn3.removeEventListener("click", removeListener);    
// }

// btn3.addEventListener("click", removeListener);

btn3.addEventListener("click", function () {
    console.log("clicked");
    btn3.removeEventListener("click", arguments.callee);
    //what is this?
    //arguments.callee is a reference to the currently executing function
});



