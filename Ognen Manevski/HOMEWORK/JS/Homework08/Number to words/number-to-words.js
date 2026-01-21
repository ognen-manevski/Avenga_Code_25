//========================================================
// #region OBJECTIVE
//========================================================

// Convert numeric input to word representation for numbers 0-1,000,000
// Technical Requirements

//     Support whole numbers only
//     Number range handling:
//         Single-digit numbers (0-9)
//         Teen numbers (10-19)
//         Tens (20-90)
//         Hundreds
//         Thousands
//         Hundreds of thousands
//         Millions

// Conversion Rules

//     English number naming conventions
//     Grammatically correct structure

// Input Validation

//     Reject non-numeric inputs
//     Limit to 0-1,000,000
//     Clear error messaging

// Test Cases

//     0 → “zero”
//     13 → “thirteen”
//     45 → “forty-five”
//     100 → “one hundred”
//     1,234 → “one thousand two hundred thirty-four”
//     999,999 → “nine hundred ninety-nine thousand nine hundred ninety-nine”

//#endregion
//========================================================

//========================================================
// #region SELECTING AND VARIABLES SETUP
//========================================================

//HTML elements
let inputDiv = document.getElementById("input");
let resultDiv = document.getElementById("result");

// Define arrays for number words
let belowTwenty = [
    "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten",
    "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen",
    "eighteen", "nineteen"];
let tens = ["", "", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety"];
let thousands = ["", "thousand", "million"];

// Thousands separators to be removed from input
let ignoredSymbols = [" ", ".", ","];

//#endregion
//========================================================

//========================================================
// #region NUMBER CONVERSION FUNCTIONS
//========================================================

// how it works:
// break number into groups of 3 digits (thousands)
// convert each group to words:
// convert numbers below 1000, below 100, below 20
// this is because english naming conventions change at these thresholds
// append appropriate scale word (thousand, million)
// combine groups into final string

// Get word for numbers below 20
function getWordBelow20(num) {
    // Direct lookup in belowTwenty array
    return belowTwenty[num];
}

// Convert numbers below 100
// calls getWordBelow20 for numbers <20
// and handles tens place for the remainder
function convertBelow100(num) {
    if (num < 20) {
        return getWordBelow20(num);
    }

    let tensWord = "";
    // Get tens place word from tens array
    // math floor (whole number) /10 to get tens place
    tensWord = tens[Math.floor(num / 10)];
    //get the remainder from num (/10 -> %10)
    let remainder = num % 10;
    if (remainder > 0) {
        //example: forty-five
        tensWord += "-" + getWordBelow20(remainder);
    }
    return tensWord;
}

// Convert numbers below 1,000
// calls convertBelow100 for remainder after hundreds place
// and handles hundreds place
function convertBelow1000(num) {
    if (num < 100) {
        return convertBelow100(num);
    }

    let hundredsWord = "";
    // Get hundreds place word from belowTwenty array
    // math floor (whole number) /100 to get hundreds place
    // example: 345 -> three + hundred
    hundredsWord = getWordBelow20(Math.floor(num / 100)) + " hundred";
    let remainder = num % 100;
    if (remainder > 0) {
        //example: three hundred + and + forty-five
        hundredsWord += " and " + convertBelow100(remainder);
    }
    return hundredsWord;
}

// Convert numbers below 1,000,000
// breaks number into groups of thousands
// calls convertBelow1000 for each group
// appends appropriate scale word (thousand)
// combines groups into final string
// uses while loop to process each group of 3 digits
// until number is reduced to 0
function convertBelow1000000(num) {

    let finalString = "";
    let thousandCounter = 0;

    // Break number into groups of 1000
    while (num > 0) {
        // Get last three digits
        let group = num % 1000;

        if (group !== 0) {
            let below1000 = convertBelow1000(group);
            // Get thousand word from thousands array
            let thousandName = thousands[thousandCounter];

            // ig number is >=1000
            if (thousandName) {
                //ex: 345,678 -> 345 + thousand + 678 (previous composite string <-prepended)
                finalString = below1000 + " " + thousandName + " " + finalString;
                //if number is <1000
            } else {
                //ex: 678 -> six hundred and seventy-eight + ""(previous composite string <-prepended)
                finalString = below1000 + " " + finalString;
            }
        }
        // Remove last three digits for next iteration
        num = Math.floor(num / 1000);
        thousandCounter++;
    }

    return finalString.trim(); // Remove extra space at the end
}

//#endregion
//========================================================

//========================================================
// #region PRINTING FUNCTIONS
//========================================================

// Display error message
function showError(message) {
    resultDiv.value = message;
}

// Display result text
function showResult(text) {
    resultDiv.value = text;
}

//#endregion
//========================================================

//========================================================
// #region INPUT PROCESSING & ERROR FEEDBACK
//========================================================

// Remove all thousand separators from input
function cleanInput(inputString) {
    let cleaned = inputString;
    for (let i = 0; i < ignoredSymbols.length; i++) {
        let separator = ignoredSymbols[i];
        // replace separators from arr. with empty string
        cleaned = cleaned.split(separator).join("");
    }
    return cleaned;
}

// Check if input contains only digits (0-9)
// ignores predefined separators (which are already removed)
function hasOnlyDigits(cleanedInput) {
    for (let i = 0; i < cleanedInput.length; i++) {
        let char = cleanedInput[i];
        // Check if character is NOT a digit (0-9)
        if (char < "0" || char > "9") {
            return false;
        }
    }
    return true;
}

// Check if input is valid and return error message if not
function validateInput(cleanedInput, num) {
    // Check if input is empty - show placeholder instead of error
    if (cleanedInput === "") {
        return "placeholder";
    }

    // Check if input contains invalid characters
    // (not numbers or separators)
    if (!hasOnlyDigits(cleanedInput)) {
        return "Invalid input: Please enter numbers only";
    }

    // Check if number is negative
    if (num < 0) {
        return "Error: Number must be positive (0 or greater)";
    }

    // Check if number is too large
    if (num > 1000000) {
        return "Error: Number must be 1,000,000 or less";
    }

    // No errors
    return null;
}

//#endregion
//========================================================

//========================================================
// #region MAIN FUNCTION
//========================================================

// Convert number to words
function numberToWords(num) {
    // Check for special cases
    if (num === 0) return "zero";
    if (num === 1000000) return "one million";

    return convertBelow1000000(num);
}

//#endregion
//========================================================

//========================================================
// #region EVENT LISTENER
//========================================================

// When input changes, run main function
inputDiv.addEventListener("input", function () {
    // Clean the input
    let cleanedInput = cleanInput(inputDiv.value);
    let num = parseInt(cleanedInput);

    // Validate input and get error message if any
    let errorMessage = validateInput(cleanedInput, num);

    if (errorMessage === "placeholder") {
        // Show placeholder message for empty input
        showResult("");
    } else if (errorMessage) {
        // Show error message
        showError(errorMessage);
    } else {
        // Convert and display result
        // Run main function
        let words = numberToWords(num);
        showResult(words);
    }
});

//#endregion
//========================================================


