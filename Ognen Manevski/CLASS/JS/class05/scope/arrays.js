// let arr = [];
// console.log(typeof arr);

// let daysOfWeek = [
//     "Monday",
//     "Tuesday",
//     "Wednesday",
//     "Thursday",
//     "Friday",
//     "Saturday",
//     "Sunday"
// ];

// let mixedArr = [null, undefined, true, false, "ognen", 54, [], {}, function test() { }];


let daysOfWeek = [
    "Monday",
    "Tuesday",
    "Wednesday",
    "Thursday",
    "Friday",
    "Saturday",
    "Sunday"
];

//get value
let dayOne = daysOfWeek[0];
let sunday = daysOfWeek[6];
let lastElement = daysOfWeek[daysOfWeek.length - 1];

//set value
daysOfWeek[3] = "New Day";
console.log(daysOfWeek);

//adding items
daysOfWeek[daysOfWeek.length] = "New value 2";
daysOfWeek.push("New value 3"); //adds to the end
daysOfWeek.push("new value 4", "new value 5");
daysOfWeek.unshift("New First Day"); //adds to the beginning
daysOfWeek.unshift("Another First Day", "Yet Another First Day");

//deleting items
daysOfWeek.pop(); //removes last item and returns it as value
daysOfWeek.shift(); //removes first item and returns it as value

let newArrLiteral = []; //creates empty array with array literal
let newArr = new Array(); //creates empty array with Array constructor

