// HOMEWORK #3
// Write a javascript function that:
// When given any array of strings (should work with array with any number of elements)
// It will create one big string and return it
// Ex:["Hello", "there", "students", "of", "SEDC", "!"]
// Result: "Hello there students of SEDC!"

let arr = ["Hello", "there", "students", "of", "SEDC", "!"];

function mergeStrings(arr) {
    let bigString = "";

    //za da nema space na kraj. mozhe i so trim()
    for (let i = 0; i < arr.length; i++) {
        if (i < arr.length - 1) {
            bigString += arr[i] + " ";
        } else {
            bigString += arr[i];
        }
    }
    console.log(bigString);
}

mergeStrings(arr);