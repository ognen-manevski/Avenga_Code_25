// ✅ JAVASCRIPT PRACTICE TASKS
// 8️⃣ Multiplication Table

// Goal: Generate a multiplication table for a given number from 1 to 10.

// Function: function multiplicationTable()

// Input:

//     Number

// Output: Multiplication table

// Test Cases:

//     Input: 5 → Output: 5 x 10 = 50
//     Input: 3 → Output: 3 x 7 = 21

function multiplicationTable(num) {

    let number;

    if (!num) {
        let number = prompt("Enter a number to generate its multiplication table:");
        number = parseInt(number);
    } else {
        number = num;
    }

    console.log(`Multiplication Table for ${number}:`);

    //from 1 to 10
    for (let i = 1; i <= 10; i++) {
        console.log(`${number} x ${i} = ${number * i}`);
    }
}

//test cases
multiplicationTable(5);
multiplicationTable(3); 