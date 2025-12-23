// 🔐 Task 3: Login Validation
// Requirements

//     Store a predefined username and password in variables.

//     Ask the user to enter a username and password using prompt().

//     Check:
//         If both the username and password match, display: "Login successful."
//         Otherwise, display: "Incorrect username or password."

// ⭐ Bonus (Invalid Input Handling)

//     If either the username or password is left empty, display: "Username and password cannot be empty."

// predefined credentials
const predefinedUsername = "ognen";
const predefinedPassword = "password123";

// get user input
let username = prompt("Enter your username:");
let password = prompt("Enter your password:");

// check for empty input
if (username === "" || password === "") {

    console.log("Username and password cannot be empty.");

} else if (username === predefinedUsername && password === predefinedPassword) {

    console.log("Login successful.");

} else {
    console.log("Incorrect username or password.");
}