// ✅ JAVASCRIPT PRACTICE TASKS
// 6️⃣ FizzBuzz

// Goal: Print numbers from 1 to 100 with specific replacement rules.

// Function: function fizzBuzz()

// Output: Sequence of numbers with "Fizz", "Buzz", or "FizzBuzz"

// Test Cases:

//     Input: 3 → Output: "Fizz"
//     Input: 5 → Output: "Buzz"
//     Input: 15 → Output: "FizzBuzz"

function fizzBuzz() {

    for (let i = 1; i <= 100; i++) {

        if (i % 3 === 0 && i % 5 === 0) {
            console.log("FizzBuzz");
        } else if (i % 3 === 0) {
            console.log("Fizz");
        } else if (i % 5 === 0) {
            console.log("Buzz");
        } else {
            console.log(i);
        }

    }
}

fizzBuzz();
