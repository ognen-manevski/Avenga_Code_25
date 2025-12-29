// Homework #6
// Title: Looping structures

// Description:Write a javascript function that:
// When given 2 arrays of students firstNames and lastNames will return a new array with students full names
// Every name should have a numeric value before it
// Ex: first = ["Bob", "Jill"], last = ["Gregory", "Wurtz"]
// Result: full = ["1. Bob Gregory", "2. Jill Wurtz"]

let first = ["Bob", "Jill", "Jane", "Mark"];
let last = ["Gregory", "Wurtz", "Doe", "Smith"];

function fullNames(firstNames, lastNames) {

    let fullNames = [];

    if (firstNames.length == lastNames.length) {

        for (let i = 0; i < firstNames.length; i++) {
            fullNames.push((i + 1) + ". " + firstNames[i] + " " + lastNames[i]);
        }
        return fullNames;

    } else {
        return "Error: The First Name and Last Name arrays have different lengths.";
    }
}

console.log(fullNames(first, last));