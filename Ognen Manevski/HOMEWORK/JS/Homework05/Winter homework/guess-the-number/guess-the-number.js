// 🎮 JavaScript Project
// Guess the Number
// 👋 What Is This Project?

// In this project, you will build a fun Guess the Number game using JavaScript.
// The computer will secretly choose a number, and the player must guess it before running out of attempts.

// You will practice:

//     Functions
//     Variables
//     prompt and parsing input
//     if / else and switch
//     Loops
//     (Bonus) Arrays

// ✅ Requirements
// 1️⃣ Function Requirement

// Your entire game must be written inside this function:

// advancedGuessingGame()


let newGameBtn = document.getElementById("new-game-btn");
newGameBtn.addEventListener("click", advancedGuessingGame);

function advancedGuessingGame() {
    //setup
    let playerName = getPlayerName();
    let difficulty = chooseDifficulty();
    let maxGuesses = getMaxGuesses(difficulty);
    let secretNumber = generateSecretNumber();

    let guesses = [];
    let didWin = false;

    //game loop
    for (let i = 0; i < maxGuesses; i++) {
        let guess = getPlayerGuess();
        guesses.push(guess);
        showGuessHistory(guesses);
        let feedback = getFeedbackMessage(guess, secretNumber);
        alert(feedback);
        if (guess === secretNumber) {
            didWin = true;
            break;
        }
    }

    //end game
    endGame(playerName, didWin, secretNumber);
}


// 2️⃣ Player Setup

//     Ask the player to enter their name
//     Display a friendly greeting, for example: “Welcome Alex! Let’s play Guess the Number!”

function getPlayerName() {
    let playerName = prompt("Enter your name:");
    alert(`Welcome ${playerName}! Let's play Guess the Number!`);
    return playerName;
}

// 3️⃣ Choose Difficulty

// Ask the player to choose a difficulty level:

//     easy
//     medium
//     hard

function chooseDifficulty() {
    let difficulty = prompt("Choose a difficulty level: easy, medium, or hard").toLowerCase();
    if (difficulty !== "easy" && difficulty !== "medium" && difficulty !== "hard") {
        alert("Invalid choice. Please choose easy, medium, or hard.");
        return chooseDifficulty();
    }
    return difficulty;
}

// Each difficulty has a different number of guesses:
// Difficulty 	Number Range 	Max Guesses
// Easy 	1–100 	12
// Medium 	1–100 	7
// Hard 	1–100 	3

function getMaxGuesses(difficulty) {
    switch (difficulty) {
        case "easy":
            return 12;
        case "medium":
            return 7;
        case "hard":
            return 3;
    }
}

// 4️⃣ Secret Number

//     The game must randomly choose one number between 1 and 100
//     This number stays the same until the game ends

function generateSecretNumber() {
    return Math.floor(Math.random() * 100) + 1;
    //mathRandom -> 0 - 0.9999
    //*100 -> 0 - 99.9999
    //math floor -> 0 - 99
    // +1 -> 1-100
}

// 5️⃣ Guessing the Number

//     The player keeps guessing until:
//         They guess the correct number, or
//         They run out of guesses

//     After each guess:
//         Show a message
//         Show how many guesses are left

function getPlayerGuess() {
    let guess = parseInt(prompt("Enter your guess (1-100):"));
    if (isNaN(guess) || guess < 1 || guess > 100) {
        alert("Invalid input. Please enter a number between 1 and 100.");
        return getPlayerGuess();
    }
    return guess;
}

// 6️⃣ How Feedback Works

// After every wrong guess, calculate how close the guess is to the secret number.
// Feedback Messages
// Distance from Secret Number 	Message
// 0 	🎉 “YES! You got it! That’s the number!”
// 1 – 5 	🔥 “WOW! That was super close! The number is shaking!”
// 6 – 10 	😄 “Nice try! You’re getting warmer!”
// 11 – 15 	🤔 “Hmm… not too close, but not terrible either.”
// More than 15 	🥶 “Way off! The number is hiding from you!”

//get random item from array
function getRandomElementFromArray(arr) {
    return arr[Math.floor(Math.random() * arr.length)];
}


function getFeedbackMessage(guess, secretNumber) {

    let distance = Math.abs(guess - secretNumber);
    //absolute value to get positive distance

    if (distance === 0) {
        let winMessages = [
            "🎉 YES! You got it! That's the number!",
            "🎉 BINGO! You nailed it!",
            "🎉 JACKPOT! You found the number!"
        ];
        return getRandomElementFromArray(winMessages);

    }
    else if (distance >= 1 && distance <= 5) {
        let closeMessages = [
            "🔥 WOW! That was super close! The number is shaking!",
            "🔥 That was almost it!",
            "🔥 You're one step away!",
            "🔥 So close it hurts!"
        ];
        return getRandomElementFromArray(closeMessages);
    }
    else if (distance >= 6 && distance <= 10) {
        let warmMessages = [
            "😄 Nice try! You're getting warmer!",
            "😄 You're on the right track!",
            "😄 Getting closer, keep going!",
            "😄 Not bad! You're in the zone!"
        ];
        return getRandomElementFromArray(warmMessages);

    }
    else if (distance >= 11 && distance <= 15) {
        let okMessages = [
            "🤔 Hmm… not too close, but not terrible either.",
            "🤔 You're in the ballpark!",
            "🤔 Not quite, but you're thinking right!",
            "🤔 Somewhere in that direction..."
        ];
        return getRandomElementFromArray(okMessages);

    }
    else {
        let coldMessages = [
            "🥶 Way off! The number is hiding from you!",
            "🥶 Brrr! That's freezing cold!",
            "🥶 Way off in the distance!",
            "🥶 You're looking in the wrong neighborhood!"
        ];
        return getRandomElementFromArray(coldMessages);
    }
}

// 7️⃣ Ending the Game
// If the player wins:

// Show a message like:

//     🎉 “Congratulations Sara! You guessed the number!”

// If the player loses:

// Show a message like:

//     😢 “Game over, Leo. The number was 42. Better luck next time!”

function endGame(playerName, didWin, secretNumber) {
    if (didWin) {
        alert(`🎉 Congratulations ${playerName}! You guessed the number!`);
    } else {
        alert(`😢 Game over, ${playerName}. The number was ${secretNumber}. Better luck next time!`);
    }
}

// ⭐ Bonus Requirements (Optional)

// Try these only after finishing the requiered part.
// 🌟 Bonus 1: Guess History

//     Store every guess in an array
//     Show all guesses at the end of the game

function showGuessHistory(guesses) {
    let historyList = document.getElementById("guess-history");
    historyList.innerHTML = "";
    guesses.forEach(guess => {
        let listItem = `<li>${guess}</li>`;
        historyList.innerHTML += listItem;
    });
}

// Example:

// Your guesses: 10, 25, 40, 42

// 🌟 Bonus 2: Play Again

//     Ask the player if they want to play another round
//     Restart the game if they say yes

// 🌟 Bonus 3: Multiple Funny Messages

//     Use different funny messages instead of repeating the same one

// Example for “very close”:

//     “That was almost it!”
//     “You’re one step away!”
//     “So close it hurts!”

// 🌟 Bonus 4: Input Safety

//     Do not accept:
//         Letters instead of numbers
//         Numbers smaller than 1 or bigger than 100
//         Invalid difficulty choices

// 🧪 Example Game Scenarios
// Example 1

//     Name: Alex
//     Difficulty: Easy
//     Secret Number: 50
//     Guess: 47

// Output:

//     🔥 “WOW! That was super close! The number is shaking!”

// Example 2

//     Name: Maria
//     Difficulty: Medium
//     Secret Number: 80
//     Guess: 65

// Output:

//     🤔 “Hmm… not too close, but not terrible either.”

// Example 3

//     Name: Leo
//     Difficulty: Hard
//     Guesses: 50, 70, 90

// Output:

//     😢 “Game over, Leo. The number was 10. Better luck next time!”

// 📝 Final Notes

//     Keep your code clean and readable
//     Use meaningful variable names
//     Make sure your game follows all the rules above



