
//exercise 1
// Select one div, one paragraph, one h1, one h3 and a button

let div = $("div").first();
let paragraph = $(".text").eq(0);
let h1 = $("h1").first();
let h3 = $("h3").first();
let button = $("button").first();
//exercise 2
//  Change the html from the previous document
//  Change the first h1 header text to "JQuery is awesome"
//  Add a new paragraph after the first header with some text
//  Change the button background to red

h1.html("JQuery is awesome");
h1.after("<p>This is a new paragraph added after the h1 header.</p>");
button.css("background-color", "red");

// Exercise 3
// Add event listener to the previous exercise button
// When clicked the button should:
// Hide the second div wrapper
// Change the color of all paragraphs to green
// Change the button text to "Don't click me"

function handleClick() {
    $("div").eq(1).hide();
    // $("div").first().next().hide();
    $("p").css("color", "green");
    button.html("Don't click me");
}

button.click(handleClick);

// Exercise 4
// Create three inputs for numbers
// Print the average of the three numbers in an h1 element
// If the average is larger or the same as 10 the result should be in green
// If the average is smaller than 10 the result should be red

let resultDiv = $("#result");
let calculateButton = $("#calculate");

function calculateAverage() {
    let num1 = parseFloat($("#num1").val());
    let num2 = parseFloat($("#num2").val());
    let num3 = parseFloat($("#num3").val());
    if (isNaN(num1) || isNaN(num2) || isNaN(num3)) {
        return;
    } else {
        let average = (num1 + num2 + num3) / 3;

        resultDiv.html("Average: " + average.toFixed(2));

        if (average >= 10) {
            resultDiv.css("color", "green");
        } else {
            resultDiv.css("color", "red");
        }
    }
}

calculateButton.click(calculateAverage);