// ✅ JAVASCRIPT PRACTICE TASKS
// 1️⃣7️⃣ Calculator with History

// Goal: Perform multiple calculations and store each result in an array.

// Function: function calculatorWithHistory()

// Input:

//     Calculations (two numbers and operator)

// Output: Array of results

// Test Cases:

//     Input: 2 + 3, 4 * 5 → Output: [5, 20]
//     Input: 10 - 4, 8 / 2 → Output: [6, 4]


//reusing switch case from previous homework
function calculatorWithHistory(calculations) {

    let results = [];

    //for each calcualtion array
    for (let calculation of calculations) {

        let num1 = calculation[0];
        let operator = calculation[1];
        let num2 = calculation[2];

        let result;

        switch (operator) {
            case '+':
                result = num1 + num2;
                break;
            case '-':
                result = num1 - num2;
                break;
            case '*':
                result = num1 * num2;
                break;
            case '/':
                result = num1 / num2;
                break;
            default:
                result = 'Invalid operator';
        }

        results.push(result);
    }
    return results;
}

// test cases 

console.log(calculatorWithHistory([[2, '+', 3], [4, '*', 5]])); // [5, 20]
console.log(calculatorWithHistory([[10, '-', 4], [8, '/', 2]])); // [6, 4]