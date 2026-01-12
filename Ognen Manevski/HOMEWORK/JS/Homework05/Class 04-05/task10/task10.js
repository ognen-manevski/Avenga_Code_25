// ✅ JAVASCRIPT PRACTICE TASKS
// 🔟 Find Longest String

// Goal: Store strings in an array and find the longest string.

// Function: function longestString()

// Input:

//     Array of strings

// Output: Longest string

// Test Cases:

//     Input: ["cat", "elephant", "dog"] → Output: "elephant"
//     Input: ["hi", "hello"] → Output: "hello"


function longestString(stringsArr) {

    let longest = "";

    for (let string of stringsArr) {
        if (string.length > longest.length) {
            longest = string;
        }
    }

    console.log(`The longest string is: "${longest}"`);
}

//test cases
let stringsArr1 = ["cat", "elephant", "dog"];
longestString(stringsArr1); // "elephant"

let stringsArr2 = ["hi", "hello"];
longestString(stringsArr2); // "hello"