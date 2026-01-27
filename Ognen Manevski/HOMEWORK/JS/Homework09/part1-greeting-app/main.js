// HOMEWORK Part 1
// Create a greeting app with JQuery
//     Create an input
//     Create a button
//     When clicked the button should print a greet message in an h1 header
// Ex: input: Petko output message: Hello there Petko!

//selecting
let btn = $("#btn");
let input = $("#text");

//greeting function

function greetUser() {
    let name = input.val();

    if (name.trim() === "") {
        alert("Please enter your name.");
        return;
    }

    let greetingMessage = `Hello there ${name}!`;
    alert(greetingMessage);
}

//event
btn.click(greetUser);