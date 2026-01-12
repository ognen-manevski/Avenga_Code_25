// ✅ JAVASCRIPT PRACTICE TASKS
// 1️⃣2️⃣ Prime Number Check

// Goal: Determine whether a number is prime.

// Function: function isPrime()

// Input:

//     Number

// Output: "Prime" or "Not Prime"

// Test Cases:

//     Input: 7 → Output: "Prime"
//     Input: 9 → Output: "Not Prime"



// A prime number is:
// A number greater than 1 that can only be divided evenly by 1 and itself.


function isPrime(number) {

    number = Math.abs(number);

    //1 is not prime
    if (number === 1) {
        console.log("Not Prime");
        return;
    }

    for (let i = 2; i < number; i++) {

        //can only be divided evenly by 1 and itself
        if (number % i === 0) {
            console.log("Not Prime");
            return;
        }
    }

    console.log("Prime");
}



//shorter version using square root
function isPrimeV2(number) {

    number = Math.abs(number);

    //1 is not prime
    if (number === 1) {
        console.log("Not Prime");
        return;
    }

    for (let i = 2; i <= Math.sqrt(number); i++) {

        //can only be divided evenly by 1 and itself
        if (number % i === 0) {
            console.log("Not Prime");
            return;
        }
    }

    console.log("Prime");
}


//test cases
isPrime(7); // Prime
isPrimeV2(7); // Prime

isPrime(9); // Not Prime
isPrimeV2(9); // Not Prime

