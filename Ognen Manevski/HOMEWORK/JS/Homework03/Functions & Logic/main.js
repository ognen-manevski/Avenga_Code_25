// 📘 JavaScript Homework – Functions & Logic
// General Rules (Read First)

//     You must write a function for every task
//     Every function must return a value
//     Only use console.log to print the returned value from the function
//     Do NOT use loops or arrays
//     Validate inputs before calculating
//     Inputs should be taken with prompt
//     All functions should be created in ONE script

// 1️⃣ minutesToSeconds(minutes)
// What to do

// Convert minutes into seconds.

//     Input must be a number
//     Negative values return null
//     0 minutes returns 0

// Expected Outputs

// minutesToSeconds(5)    → 300
// minutesToSeconds(0)    → 0
// minutesToSeconds(-2)   → null
// minutesToSeconds("5")  → null

let minutesToSeconds = function (minutes) {
    if (!Number.isNaN(minutes) && minutes >= 0) {
        return minutes * 60;
    }
    return null;
}


// 2️⃣ hoursToMinutes(hours)
// What to do

// Convert hours into minutes.

//     Input must be a number
//     Negative values return null

// Expected Outputs

// hoursToMinutes(2)    → 120
// hoursToMinutes(0)    → 0
// hoursToMinutes(-1)   → null
// hoursToMinutes("2")  → null

let hoursToMinutes = function (hours) {
    if (!Number.isNaN(hours) && hours >= 0) {
        return hours * 60;
    }
    return null;
}


// 3️⃣ hoursToSeconds(hours)
// What to do

// Convert hours into seconds.

//     Validate input
//     Return null if invalid

// Expected Outputs

// hoursToSeconds(1)    → 3600
// hoursToSeconds(0)    → 0
// hoursToSeconds(-1)   → null
// hoursToSeconds("1")  → null

let hoursToSeconds = function (hours) {
    if (!Number.isNaN(hours) && hours >= 0) {
        return hours * 3600;
    }
    return null;
}


// 4️⃣ daysToHours(days)
// What to do

// Convert days into hours.

//     Input must be a number
//     Negative values return null

// Expected Outputs

// daysToHours(1)    → 24
// daysToHours(0)    → 0
// daysToHours(-1)   → null
// daysToHours("1")  → null

let daysToHours = function (days) {
    if (!Number.isNaN(days) && days >= 0) {
        return days * 24;
    }
    return null;
}

// 5️⃣ daysToSeconds(days)
// What to do

// Convert days into seconds.

//     Validate input
//     Return null if invalid

// Expected Outputs

// daysToSeconds(1)    → 86400
// daysToSeconds(0)    → 0
// daysToSeconds(-1)   → null
// daysToSeconds("1")  → null

let daysToSeconds = function (days) {
    if (!Number.isNaN(days) && days >= 0) {
        return days * 86400;
    }
    return null;
}

// 6️⃣ isTruthyValue(value)
// What to do

// Check whether a value is truthy or falsy.

//     Return true if truthy
//     Return false if falsy

// Expected Outputs

// isTruthyValue(1)     → true
// isTruthyValue(0)     → false
// isTruthyValue("hi")  → true
// isTruthyValue("")    → false

let isTruthy = function (value) {
    if (value) {
        return true;
    }
    return false;
}

// 7️⃣ areBothTruthy(a, b)
// What to do

// Check if both values are truthy.
// Expected Outputs

// areBothTruthy(1, "a")   → true
// areBothTruthy(1, 0)     → false
// areBothTruthy("", "a")  → false
// areBothTruthy(true, 1)  → true

let areBothTruthy = function (a, b) {
    if (a && b) {
        return true;
    }
    return false;
}


// 8️⃣ getStringLength(text)
// What to do

// Return the length of a string.

//     Empty string returns 0
//     Invalid input returns null

// Expected Outputs

// getStringLength("hello")  → 5
// getStringLength("")       → 0
// getStringLength("a")      → 1
// getStringLength(5)        → null

let getStringLength = function (text) {
    if (typeof text === "string") {
        return text.length;
    }
    return null;
}


// 9️⃣ getFirstAndLastChar(text)
// What to do

// Return the first and last character together.

//     Input must be a string
//     Strings shorter than 2 characters return null

// Expected Outputs

// getFirstAndLastChar("hello")  → "ho"
// getFirstAndLastChar("ab")     → "ab"
// getFirstAndLastChar("a")      → null
// getFirstAndLastChar(5)        → null

let getFirstAndLastChar = function (text) {
    if (typeof text === "string" && text.length >= 2) {
        return text[0] + text[text.length - 1];
    }
    return null;
}

// 🔟 capitalizeIfLong(text)
// What to do

// Capitalize the first letter only if the string has 5 or more characters.
// Expected Outputs

// capitalizeIfLong("hello")  → "Hello"
// capitalizeIfLong("world")  → "World"
// capitalizeIfLong("hi")     → "hi"
// capitalizeIfLong(5)        → null

let capitalizeIfLong = function (text) {
    if (typeof text === "string" && text.length >= 5) {
        return text[0].toUpperCase() + text.slice(1).toLowerCase(); //prvata bukva golema, ostanatite mali

    } else if (typeof text === "string") {
        return text;
    }
    return null;
}


// 1️⃣1️⃣ isVowel(char)
// What to do

// Check if a single character is a vowel (a, e, i, o, u).

//     Ignore letter case

// Expected Outputs

// isVowel("a")  → true
// isVowel("E")  → true
// isVowel("b")  → false
// isVowel("ab") → false

let isVowel = function (char) {
    if (typeof char === "string" && char.length === 1) {
        let lowerChar = char.toLowerCase(); //Ignore letter case
        switch (lowerChar) {
            case 'a':
            case 'e':
            case 'i':
            case 'o':
            case 'u':
                return true;
            default:
                return false;
        }
    }
    return false;
}

// 1️⃣2️⃣ getLargerNumber(a, b)
// What to do

// Return the larger number.

//     If numbers are equal, return one of them
//     Invalid input returns null

// Expected Outputs

// getLargerNumber(5, 10)   → 10
// getLargerNumber(7, 7)    → 7
// getLargerNumber(-1, 2)   → 2
// getLargerNumber("5", 2)  → null

let getLargerNumber = function (a, b) {
    if (typeof a === "number" && typeof b === "number") {
        if (a >= b) {
            return a;
        } else {
            return b;
        }
    }
    return null;
}

// 1️⃣3️⃣ getMiddleNumber(a, b, c)
// What to do

// Return the number that is neither the smallest nor the largest.

//     All values must be different
//     Invalid input returns null

// Expected Outputs

// getMiddleNumber(1, 2, 3)  → 2
// getMiddleNumber(3, 1, 2)  → 2
// getMiddleNumber(2, 2, 3)  → null
// getMiddleNumber("1", 2, 3)→ null

let getMiddleNumber = function (a, b, c) {
    if (typeof a === "number" && typeof b === "number" && typeof c === "number") {

        if ((a > b && a < c) || (a < b && a > c)) {
            return a;
        } else if ((b > a && b < c) || (b < a && b > c)) {
            return b;
        } else if ((c > a && c < b) || (c < a && c > b)) {
            return c;
        } else {
            return null;
        }

        // switch (true) {
        //     case (a > b && a < c) || (a < b && a > c):
        //         return a;
        //     case (b > a && b < c) || (b < a && b > c):
        //         return b;
        //     case (c > a && c < b) || (c < a && c > b):
        //         return c;
        //     default:
        //         return null; //znachi ima isti values
        // }

    }
    return null;
}

// 1️⃣4️⃣ formatFullName(firstName, lastName)
// What to do

// Return a formatted full name.

//     Both values must be strings
//     If either value is falsy, return null
//     Format: "LastName, FirstName"

// Expected Outputs

// formatFullName("John", "Doe")  → "Doe, John"
// formatFullName("Jane", "Lee")  → "Lee, Jane"
// formatFullName("", "Doe")      → null
// formatFullName(5, "Doe")       → null

let formatFullName = function (firstName, lastName) {
    if (firstName && lastName && typeof firstName === "string" && typeof lastName === "string") {
        //golema bukva
        firstName = firstName[0].toUpperCase() + firstName.slice(1).toLowerCase();
        lastName = lastName[0].toUpperCase() + lastName.slice(1).toLowerCase();
        //format
        return `${lastName}, ${firstName}`;
    }
    return null;
}

// 1️⃣5️⃣ isValidUsername(username)
// What to do

// Validate a username.

//     Must be a string
//     Length between 5 and 12
//     Must NOT start with a number

// Expected Outputs

// isValidUsername("user12")   → true
// isValidUsername("1user")    → false
// isValidUsername("abc")      → false
// isValidUsername("longusername123") → false

let isValidUsername = function (username) {
    if (typeof username === "string" && username.length >= 5 && username.length <= 12) {
        //ako e broj
        let firstChar = username[0];
        firstChar = parseInt(firstChar);
        if (isNaN(firstChar)) {
            return true;
        }
        return false;
    }
    return false;
}



