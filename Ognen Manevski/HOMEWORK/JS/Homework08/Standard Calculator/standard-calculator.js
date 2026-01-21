//#region INSTRUCTIONS
// Now it’s time for some more challenges! Create a web calculator with all the standard features.
//     The calculator should have buttons for the numbers to click (just like calculators in real life, no inputs!).
//     It should have buttons for the operations: Sum, Subtract, Multiply and Divide.
//     It should also have the standard buttons equals, decimal dot and reset ( C ).
//     There should be a display where we can see the numbers that we are entering and results (like calculators in real life).
//     The calculator should show error message if number is too large or if we are dividing by zero.
// NOTE: The eval() function is not allowed!
//#endregion

//================================================================
// #region SELECTING ELEMENTS
//================================================================

//buttons
let buttons = document.querySelectorAll("button");

//display
let display = document.getElementById("display");

//#endregion
//================================================================

//================================================================
// #region STATE VARIABLES
//================================================================

let currentInput = "";
let previousInput = "";
let operation = null;
let resultDisplayed = false;
let MAX_LENGTH = 12;
let ERROR_MESSAGE = "Error";

// operation to symbol mapping
let operationSymbols = {
    "add": "+",
    "subtract": "−",
    "multiply": "×",
    "divide": "÷"
};

// operation functions mapping
let operations = {
    "add": add,
    "subtract": subtract,
    "multiply": multiply,
    "divide": divide
};

//#endregion
//================================================================

//================================================================
// #region OPERATION & BUTTON FUNCTIONS
//================================================================

//addition
function add(a, b) {
    return a + b;
}

//subtraction
function subtract(a, b) {
    return a - b;
}

//multiplication
function multiply(a, b) {
    return a * b;
}

//division
function divide(a, b) {
    if (b === 0) {
        return ERROR_MESSAGE;
    }
    return a / b;
}

//reset calculator
function resetCalculator() {
    currentInput = "";
    previousInput = "";
    operation = null;
    resultDisplayed = false;
    updateDisplay("0");
}

//delete last character
function deleteLastCharacter() {
    //slice off the last character
    //from index 0 to the last character (not included)
    currentInput = currentInput.slice(0, -1);
    updateDisplay(getDisplayValue());
}

//equals button clicked
function equalsButtonClicked() {
    if (operation === null || currentInput === "" || previousInput === "") {
        return;
    }
    let result = performCalculation();
    updateDisplay(result);
    currentInput = result.toString();
    previousInput = "";
    operation = null;
    resultDisplayed = true;
}

//#endregion
//================================================================

//================================================================
// #region UTILITY FUNCTIONS
//================================================================

//convert string to number
function parseInput(input) {
    return parseFloat(input);
}

//check if input length exceeds max length
function isInputTooLong(input) {
    return input.length > MAX_LENGTH;
}

//check if input is a valid number
function isValidNumber(input) {
    return !isNaN(parseFloat(input)) && isFinite(input);
}

//#endregion
//================================================================

//================================================================
// #region MAIN CALCULATION FUNCTION
//================================================================

//perform calculation based on the selected operation
function performCalculation() {
    let a = parseInput(previousInput);
    let b = parseInput(currentInput);
    if (!isValidNumber(a) || !isValidNumber(b)) {
        return ERROR_MESSAGE;
    }
    if (!operations[operation]) {
        return currentInput;
    }
    //operations mapped with functions
    return operations[operation](a, b);
}

//#endregion
//================================================================

//================================================================
// #region BUTTON HANDLER HELPER FUNCTIONS
//================================================================

// handle number button clicks
function handleNumberButton(buttonValue) {
    if (resultDisplayed) {
        currentInput = buttonValue;
        resultDisplayed = false;
    } else {
        currentInput += buttonValue;
    }
    refreshDisplay();
}

// handle decimal button clicks
function handleDecimalButton() {
    if (resultDisplayed) {
        currentInput = "0.";
        resultDisplayed = false;
        //if decimal not already present, add it
    } else if (!currentInput.includes(".")) {
        if (currentInput === "") {
            currentInput = "0.";
        } else {
            currentInput += ".";
        }
    }
    refreshDisplay();
}

// handle operator button clicks
function handleOperatorButton(buttonId) {
    // allow negative numbers - if subtract pressed and currentInput is empty
    if (buttonId === "subtract" && currentInput === "") {
        currentInput = "-";
        refreshDisplay();
        return;
    }
    //if current input is empty, do nothing
    if (currentInput === "") return;
    // perform the calculation
    if (previousInput !== "") {
        let result = performCalculation();
        updateDisplay(result);
        currentInput = result.toString();
    }
    previousInput = currentInput;
    currentInput = "";
    operation = buttonId; // directly use buttonId which matches operation names
    refreshDisplay();
}

//#endregion
//================================================================

//================================================================
// #region INTERPRETING BUTTON CLICKS - EVENT LISTENERS SETUP
//================================================================

// main button click handler
buttons.forEach(button => {
    button.addEventListener("click", function () {
        let buttonId = button.id;
        let buttonValue = button.innerText;

        if (button.classList.contains("btn-number")) {
            handleNumberButton(buttonValue);
        } else if (buttonId === "decimal") {
            handleDecimalButton();
        } else if (button.classList.contains("btn-operator")) {
            handleOperatorButton(buttonId);
        } else if (buttonId === "equals") {
            equalsButtonClicked();
        } else if (buttonId === "clear") {
            resetCalculator();
        } else if (buttonId === "backspace") {
            deleteLastCharacter();
        }
    });
});

//#endregion
//================================================================

//================================================================
// #region DISPLAY FUNCTIONS
//================================================================

//update display
function updateDisplay(value) {
    // check if numeric input is too long (not the formatted display)
    if (isInputTooLong(currentInput)) {
        display.innerText = ERROR_MESSAGE;
        return;
    }
    display.innerText = value;
}

//format display to show operation
function getDisplayValue() {
    if (operation === null) {
        return currentInput || "0";
    }
    let operationSymbol = operationSymbols[operation];
    // if currentInput is empty, don't show the 0 placeholder
    if (currentInput === "") {
        return previousInput + " " + operationSymbol;
    }
    return previousInput + " " + operationSymbol + " " + currentInput;
}

// refresh display with formatted value
function refreshDisplay() {
    updateDisplay(getDisplayValue());
}

//#endregion
//================================================================

//================================================================
// #region INITIAL SETUP
//================================================================

//initialize display
// updateDisplay("0");

//#endregion
//================================================================




