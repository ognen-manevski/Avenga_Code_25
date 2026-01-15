// Print all numbers from an array and the sum

//     Create an array with numbers
//     Print all numbers from the array in a list element, in the HTML page
//     Print out the sum of all of the numbers below the list
//     Bonus: Try printing the whole mathematical equasion as well ( 2 + 4 + 5 = 11)

let resultsDiv = document.getElementById("results-div");

let numbersArr = [2, 4, 5, 10, 20];

function printNumbersfromArray(arr) {
    resultsDiv.innerHTML = `
    <h4>Numbers from the array:</h4>
    <ul>
    `;
    for (let num in arr) {
        resultsDiv.innerHTML += `<li>${arr[num]}</li>`;
    }
    resultsDiv.innerHTML += `</ul>`;
}

function printSumOfNumbers(arr) {

    //initialize
    let sum = 0;
    let mathEqString = "";

    //calcualte sum and equation string
    for (let num in arr) {
        //sum
        sum += arr[num];

        //string concatenation
        if (num < arr.length - 1) {
            mathEqString += arr[num] + " + ";
        } else {
            mathEqString += arr[num];
        }
    }

    mathEqString += " = " + sum;

    //print
    resultsDiv.innerHTML += `
    <h4>Sum of all numbers: ${sum}</h4>
    <h4>Mathematical equation: ${mathEqString}</h4>
    `;
}

// calls
printNumbersfromArray(numbersArr);
printSumOfNumbers(numbersArr);