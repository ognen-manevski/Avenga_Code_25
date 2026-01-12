// ✂️🪨📄 JavaScript Project
// Rock–Paper–Scissors Tournament
// 👋 What Is This Game?

// You will create a Rock–Paper–Scissors game where the player competes against the computer. The game will include:

//     Choosing a player name
//     Selecting a number of rounds
//     Keeping track of scores
//     Declaring a winner at the end

// You will practice:

//     Functions
//     Loops
//     Arrays
//     Control flow (if/else, switch)
//     prompt input and parsing

// 🎯 Goal

// Build a Rock–Paper–Scissors game where:

//     The player enters their name
//     The player chooses number of rounds

//     In each round:
//         The player picks Rock, Paper, or Scissors
//         The computer randomly chooses Rock, Paper, or Scissors
//         Determine the winner of the round
//         Show a fun message based on the outcome
//     Keep score and declare the overall winner after all rounds

// ✅ Requirements
// 1️⃣ Function Requirement

// All your game logic must be inside this function:

// rockPaperScissorsGame()


let newGameBtn = document.getElementById("new-game-btn");
newGameBtn.addEventListener("click", rockPaperScissorsGame);

function rockPaperScissorsGame() {

    //get history list element
    let historyList = document.getElementById("round-history");

    //clear previous history
    let roundHistory = [];
    historyList.innerHTML = "";

    //setup
    let choices = ["rock", "paper", "scissors"];
    let playerName = getPlayerName();
    let rounds = getRounds();
    let playerScore = 0;
    let computerScore = 0;

    //game rounds loop
    for (let round = 1; round <= rounds; round++) {

        let playerChoice = getPlayerChoice(choices);
        let computerChoice = getComputerChoice(choices);

        let roundWinner = determineRoundWinner(playerChoice, computerChoice);

        //display alert feedback message
        roundFeedbackMsg(roundWinner, playerName, playerChoice, computerChoice);

        //update scores
        if (roundWinner === "player") {
            playerScore++;
        }
        else if (roundWinner === "computer") {
            computerScore++;
        }
        //display current score alert
        displayScore(playerName, playerScore, computerScore);

        //save round to history
        let resultText = determineResultText(roundWinner, playerChoice, computerChoice);
        let resultTextWithRound = `Round ${round}: ${resultText}`;
        roundHistory.push(resultTextWithRound);
        updateRoundHistoryDisplay(historyList, resultTextWithRound);
    }

    //end game
    declareOverallWinner(playerName, playerScore, computerScore);

    //play again?
    playAgainPrompt()
}

// 2️⃣ Player Setup

//     Ask the player to enter their name
//     Display a greeting: “Welcome Alex! Get ready for Rock–Paper–Scissors!”

function getPlayerName() {
    let playerName = prompt("Enter your name:");
    alert(`Welcome ${playerName}! Get ready for Rock–Paper–Scissors!`);
    return playerName;
}


// 3️⃣ Number of Rounds

//     Ask the player how many rounds they want to play
//     Store the number of rounds in a variable
//     Loop through that many rounds


function getRounds() {
    let rounds = parseInt(prompt("How many rounds do you want to play? 1, 3, or 5?"));
    if (rounds !== 1 && rounds !== 3 && rounds !== 5) {
        alert("Please enter a valid number of rounds.");
        return getRounds();
    }
    return rounds;
}

// 4️⃣ Player & Computer Choices

//     Each round, ask the player to choose:
//         "rock"
//         "paper"
//         "scissors"

//     Generate a random choice for the computer using an array:

//     ["rock", "paper", "scissors"]


function getPlayerChoice(choices) {
    let playerChoice = prompt("Choose rock, paper, or scissors:").toLowerCase();
    if (playerChoice !== "rock" && playerChoice !== "paper" && playerChoice !== "scissors") {
        alert("Invalid choice. Please choose rock, paper, or scissors.");
        return getPlayerChoice(choices);
    } else {
        return playerChoice;
    }
}

function getComputerChoice(choices) {
    let randomIndex = Math.floor(Math.random() * choices.length);
    //mathRandom returns a number between 0 and 1 * length of the array (3)
    //math floor rounds DOWN to the nearest whole number
    //thats 0, 1, or 2 
    let computerChoice = choices[randomIndex];
    return computerChoice;
}


// 5️⃣ Determine Round Winner

//     Compare the player’s choice vs computer choice using if/else or switch

//     Rules:
//         Rock beats Scissors
//         Paper beats Rock
//         Scissors beats Paper
//         Same choice = Tie

function determineRoundWinner(playerChoice, computerChoice) {
    // Check if it's a tie
    if (playerChoice === computerChoice) {
        return "tie";
    }
    // Check if player wins
    if ((playerChoice === "rock" && computerChoice === "scissors") ||
        (playerChoice === "paper" && computerChoice === "rock") ||
        (playerChoice === "scissors" && computerChoice === "paper")) {
        return "player";
    }
    // Otherwise computer wins
    return "computer";
}

// 6️⃣ Round Feedback Messages

// If the player wins:

//     🎉 “You win this round! Nice one, Alex!”

// If the computer wins:

//     💻 “Computer takes this round! Don’t give up!”

// If it’s a tie:

//     🤝 “It’s a tie! Try again!”

function roundFeedbackMsg(roundWinner, playerName, playerChoice, computerChoice) {
    if (roundWinner === "player") {
        // Player wins - matchup-specific messages
        if (playerChoice === "rock" && computerChoice === "scissors") {
            alert(`🎉 Boom! Rock crushes scissors! ${playerName} wins this round!`);
        } else if (playerChoice === "paper" && computerChoice === "rock") {
            alert(`🎉 Paper smothers rock! Nice, ${playerName}!`);
        } else if (playerChoice === "scissors" && computerChoice === "paper") {
            alert(`🎉 Snip snip! Scissors cut paper! ${playerName} wins!`);
        }
    }
    else if (roundWinner === "computer") {
        // Computer wins - matchup-specific messages
        if (computerChoice === "rock" && playerChoice === "scissors") {
            alert(`💻 Oh no! Rock crushes your scissors! Computer wins this round!`);
        } else if (computerChoice === "paper" && playerChoice === "rock") {
            alert(`💻 Oops! Paper smothers your rock! Computer takes this round!`);
        } else if (computerChoice === "scissors" && playerChoice === "paper") {
            alert(`💻 Snip snip! Scissors cut your paper! Computer wins!`);
        }
    } else {
        // Tie
        alert(`🤝 Both chose ${playerChoice}. It's a tie! Try again!`);
    }
}


// 7️⃣ Score Tracking

//     Keep track of both player and computer wins in variables

//     Display the current score after each round:

//     Score: Alex 2 – Computer 1

function displayScore(playerName, playerScore, computerScore) {
    alert(`Score: ${playerName}: ${playerScore} – Computer: ${computerScore}`);
}


// 8️⃣ End of Game

//     After all rounds, declare the overall winner:

// Examples:

//     Player wins: 🎉 “Congratulations Alex! You won the tournament 3–1!”
//     Computer wins: 💻 “Game over! The computer won 4–2.”
//     Tie: 🤝 “It’s a tie tournament! Both scored 3.”


function declareOverallWinner(playerName, playerScore, computerScore) {
    if (playerScore > computerScore) {
        alert(`🎉 Congratulations ${playerName}! You won the tournament ${playerScore}–${computerScore}!`);
    }
    else if (computerScore > playerScore) {
        alert(`💻 Game over! The computer won ${computerScore}–${playerScore}.`);
    } else {
        alert(`🤝 It’s a tie tournament! Both scored ${playerScore}.`);
    }
}

// ⭐ Bonus 4: Scoreboard Array

//     Store each round result in an array
//     Show a summary at the end:
//     Round 1: Alex won
//     Round 2: Tie
//     Round 3: Computer won

function determineResultText(roundWinner, playerChoice, computerChoice) {
    if (roundWinner === "player") {
        return `${playerChoice} beats ${computerChoice}. You win!`;
    } else if (roundWinner === "computer") {
        return `${computerChoice} beats ${playerChoice}. Computer wins!`;
    } else {
        return `Both chose ${playerChoice}. It's a tie!`;
    }
}

function updateRoundHistoryDisplay(historyList, resultTextWithRound) {
    historyList.innerHTML += `<li>${resultTextWithRound}</li>`;
}


// ⭐ Bonus Requirements (Optional)
// 🌟 Bonus 1: Fun Messages per Choice

//     Show different funny messages depending on the match-up, e.g.:
//         Rock vs Scissors → “Boom! Rock crushes scissors!”
//         Paper vs Rock → “Paper smothers rock! Nice!”
//         Scissors vs Paper → “Snip snip! Scissors win!”

// 🌟 Bonus 2: Input Validation

//     Don’t accept invalid inputs (e.g., “roc” or numbers)
//     Ask the player again if input is invalid

// 🌟 Bonus 3: Play Again

//     Ask the player if they want to start another tournament after finishing
//     Reset scores for the new game

function playAgainPrompt() {
    let playAgain = confirm("Do you want to play another tournament?");
    if (playAgain) {
        rockPaperScissorsGame();
        //resets scores automatically
    }
}

// 🌟 Bonus 4: Scoreboard Array

//     Store each round result in an array

//     Show a summary at the end:

//     Round 1: Alex won
//     Round 2: Tie
//     Round 3: Computer won

// 🧪 Example Game Scenario

// Scenario 1

//     Name: Emma
//     Rounds: 3

// Round 	Player 	Computer 	Result 	Message
// 1 	rock 	scissors 	Player wins 	🎉 “You win this round! Nice one, Emma!”
// 2 	paper 	rock 	Player wins 	🎉 “You win this round! Nice one, Emma!”
// 3 	scissors 	scissors 	Tie 	🤝 “It’s a tie! Try again!”

// End Message: 🎉 “Congratulations Emma! You won the tournament 2–0–1!”
// 📝 Notes

//     Make your code clean and readable
//     Use arrays for computer choices and optional round history
//     Use loops for rounds
//     Make the game interactive and fun


