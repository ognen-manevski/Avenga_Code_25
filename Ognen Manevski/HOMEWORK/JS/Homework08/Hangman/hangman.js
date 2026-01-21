//==================================================================
// #region TASK DESCRIPTION
//==================================================================

// Create a web page that will allow the user to play the hangman game against the computer.
// The rules of hangman are this:
// We have to guess a word by guessing individual letters.
// We have a set number of lives and lose a life each time we make a wrong guess.
// It's a game where the unknown word is displayed as dashes, with letters fill in as we guess them.
// Thinking about this programmatically, we can see that the state of the game at any time can be represented through the use of a
//  limited number of variables and operations on these variables.
// At the start of the game we choose a word to be guessed. The word will be a random choice from the program out of a many options that are saved in the game.
// You can choose certain topic e.q. movies / TV shows.
// We also have a number of lives, which is the total number of wrong guesses we are allowed.
// You set this in advance (it usually is 6 – for each part of the hangman itself (head, body, 2 arms, 2 legs).
// You lose a life when you have a wrong guess.
// Finally, we have our guesses, the letters that we have guessed so far. Dashes are replaced with the guessed letters.
// The game has three possible states - Victory (all letters guessed), Death (no more lives left) or Still Playing. 
// All of these can be figured out using the above three variables.
// It's worth emphasizing that the lives, or maximum number of wrong guesses, and the word are set at the start of the game.
// The only thing that changes throughout the course of a game is the guessed letters, and everything else follows on from that.
// BONUS: A sketch of the scaffold is added to each time there's a wrong guess. If the sketch is completed before we complete the game, then we lose!

//#endregion
//==================================================================

//==================================================================
// #region SELECTING ELEMENTS AND GLOBAL VARIABLES
//==================================================================

// Word lists by topic
let wordsList = {
    "Programming Languages": ["JAVASCRIPT", "PYTHON", "RUBY", "JAVA", "CPLUSPLUS", "SWIFT", "KOTLIN", "TYPESCRIPT"],
    "Movies": ["INCEPTION", "GLADIATOR", "TITANIC", "AVATAR", "CASABLANCA", "ALIEN", "JOKER", "FROZEN"],
    "Countries": ["ARGENTINA", "AUSTRALIA", "BELGIUM", "CAMBODIA", "DENMARK", "ETHIOPIA", "FINLAND", "GUATEMALA"]
}

// Get HTML elements
let resultCaption = document.getElementById('result-caption');
let wordContainer = document.getElementById('word-container');
let keyboardContainer = document.getElementById('keyboard-container');
let hintBtn = document.getElementById('hint-btn');
let newGameBtn = document.getElementById('new-game-btn');
let topicsSelect = document.getElementById('topics');
let livesDisplay = document.getElementById('lives-display');

// Hangman body parts (in order of drawing)
let bodyParts = [
    document.querySelectorAll('.head'),
    document.querySelectorAll('.torso'),
    document.querySelectorAll('.left-arm'),
    document.querySelectorAll('.right-arm'),
    document.querySelectorAll('.left-leg'),
    document.querySelectorAll('.right-leg')
];
let eyes = document.getElementById('eyes');

// Store current game's guessLetter callback function
// guessLetter(letter) will be defined inside playGame()
// and assigned to this variable for global access
let guessLetterCallback = null;

//#endregion
//==================================================================

//==================================================================
// #region KEYBOARD FUNCTIONS
//==================================================================

// Create all letter buttons A-Z
function createKeyboard() {
    let letters = 'ABCDEFGHIJKLMNOPQRSTUVWXYZ';
    let html = '';
    for (let letter of letters) {
        html += `<button class="key-btn" id="key-${letter}">${letter}</button>`;
    }
    keyboardContainer.innerHTML = html;
}

// Reset all keyboard buttons (called every new game)
function resetKeyboard() {
    let buttons = document.querySelectorAll('.key-btn');
    buttons.forEach(button => button.disabled = false);
}

// Disable a letter button (when guessed)
function disableLetterButton(letter) {
    let button = document.getElementById(`key-${letter}`);
    if (button) {  // ← Check if button exists before disabling
        button.disabled = true;
    }
}

// Physical keyboard listener (called once)
// uses guessLetter(letter) from current game
function setupPhysicalKeyboard() {
    document.addEventListener('keydown', function (e) {
        // Get the key pressed
        // pressing a key creates an event with a 'key' property
        let keyPressed = e.key;
        // Convert it to uppercase (A-Z)
        let letter = keyPressed.toUpperCase();
        // Only process A-Z keys
        if (letter >= 'A' && letter <= 'Z') {
            // Call the current game's guessLetter function
            if (guessLetterCallback) {
                guessLetterCallback(letter);
            }

            // Flash the button for UX
            let button = document.getElementById(`key-${letter}`);
            if (button) {
                button.classList.add('flash');
                setTimeout(function () {
                    button.classList.remove('flash');
                }, 100);
            }
        }
    });
}

// Virtual keyboard listener (called once)
// uses guessLetter(letter) from current game
function setupVirtualKeyboard() {
    let buttons = document.querySelectorAll('.key-btn');
    buttons.forEach(button => {
        button.onclick = function () {
            if (guessLetterCallback) {
                //call the function with the pressed letter
                //this is the button that was clicked
                guessLetterCallback(this.textContent);
            }
        };
    });
}
//#endregion
//==================================================================

//==================================================================
// #region TOPIC FUNCTIONS
//==================================================================

// Create topic dropdown options
function createTopicDropdown() {
    let html = '';
    for (let topic of Object.keys(wordsList)) {
        html += `<option value="${topic}">${topic}</option>`;
    }
    topicsSelect.innerHTML = html;
}

// Get selected topic from dropdown
function getSelectedTopic() {
    return topicsSelect.value;
}

// Get random word from topic
function getRandomWord(topic) {
    let words = wordsList[topic];
    let randomIndex = Math.floor(Math.random() * words.length);
    return words[randomIndex];
}

//topcis dropdown onchange listener
function setupTopicSelect() {
    topicsSelect.addEventListener('change', playGame);
}

//#endregion
//==================================================================

//==================================================================
// #region WORD DISPLAY FUNCTIONS
//==================================================================

// Create placeholder boxes for each letter
function createWordDisplay(word) {
    let html = '';
    for (let i = 0; i < word.length; i++) {
        html += `<div class="letter-placeholder" id="letter-${i}"></div>`;
    }
    wordContainer.innerHTML = html;
}

// Show a guessed letter in the display
function revealLetter(word, letter) {
    for (let i = 0; i < word.length; i++) {
        if (word[i] === letter) {
            let box = document.getElementById(`letter-${i}`);
            box.textContent = letter;
        }
    }
}

// Show all remaining letters at game end
function revealWord(word) {
    for (let i = 0; i < word.length; i++) {
        let box = document.getElementById(`letter-${i}`);
        if (box.textContent === '') {
            box.textContent = word[i];
            box.style.color = 'rgba(0, 0, 0, 0.3)';
        }
    }
}
//#endregion
//==================================================================

//==================================================================
// #region HANGMAN DRAWING FUNCTIONS
//==================================================================

// Make hangman parts visible
function showParts(part) {
    part.forEach(p => p.style.opacity = '1');
}

// Hide hangman parts
function hideParts(part) {
    part.forEach(p => p.style.opacity = '');
}

// Update hangman drawing based on mistakes
function updateHangmanDisplay(mistakes) {
    // Reset all parts
    bodyParts.forEach(part => hideParts(part));
    eyes.textContent = 'O  O';
    
    // Show parts sequentially based on mistakes
    for (let i = 0; i < mistakes; i++) {
        showParts(bodyParts[i]);
    }
    
    // Update eyes if game lost
    if (mistakes >= 6) {
        eyes.textContent = 'X  X';
    }
}
//#endregion
//==================================================================

//==================================================================
// #region HINT FUNCTIONS
//==================================================================

// Find random unguessed letter
function getHintLetter(word, guessedLetters) {
    let missingLetters = [];
    for (let letter of word) {
        if (!guessedLetters.includes(letter)) {
            missingLetters.push(letter);
        }
    }
    if (missingLetters.length > 0) {
        hintBtn.disabled = true;
        let randomIndex = Math.floor(Math.random() * missingLetters.length);
        return missingLetters[randomIndex];
    } else {
        return null;
    }
}

//#endregion
//==================================================================

//==================================================================
// #region RESULT DISPLAY FUNCTIONS
//==================================================================

// Show win/lose message
function showResult(type) {
    resultCaption.textContent = '';
    resultCaption.classList.remove('win', 'lose');
    if (type === 'victory') {
        resultCaption.textContent = 'Congratulations! You won!';
        resultCaption.classList.add('win');
        newGameBtn.focus(); //for easier replay on keyboard
    } else if (type === 'defeat') {
        resultCaption.textContent = 'Game Over! You lost!';
        resultCaption.classList.add('lose');
        newGameBtn.focus(); //for easier replay on keyboard
    }
}

// Display remaining lives
function displayLives(lives) {
    let text = lives.toString();
    if (text.length === 1) {
        text = `0${text}`;
    }
    livesDisplay.textContent = text;
}

//#endregion
//==================================================================

//==================================================================
// #region NEW GAME BUTTON
//==================================================================

// Setup new game button listener (called once)
function setupNewGameBtn() {
    newGameBtn.onclick = function () {
        playGame();
    };
}
//#endregion
//==================================================================

//==================================================================
// #region MAIN GAME LOGIC
//==================================================================

function playGame() {
    // game state variables
    let topic = getSelectedTopic();
    let word = getRandomWord(topic);
    let guessedLetters = [];
    let correctLetters = 0;
    let wordLetters = getUniqueLetters(word);
    let mistakes = 0;
    let maxMistakes = 6;
    let isGameOver = false;

    // Setup game display
    resetKeyboard();
    createWordDisplay(word);
    updateHangmanDisplay(0);
    showResult('');
    hintBtn.disabled = false;

    //==================================================================
    // #region INGAME FUNCTIONS
    //==================================================================
    //these functions must have access to the game state variables
    //and passing them as parameters would be complicated

    // Get unique letters array from word
    function getUniqueLetters(word) {
        let uniqueLetters = [];
        for (let letter of word) {
            if (!uniqueLetters.includes(letter)) {
                uniqueLetters.push(letter);
            }
        }
        return uniqueLetters;
    }

    // Check if letter is in the word
    function isLetterInWord(letter) {
        return word.includes(letter);
    }

    // Check if all letters are guessed
    function checkVictory() {
        return correctLetters === wordLetters.length;
    }

    // Handle correct guess
    function handleCorrectGuess(letter) {
        revealLetter(word, letter);
        correctLetters++;
        if (checkVictory()) {
            showResult('victory');
            isGameOver = true;
            hintBtn.disabled = true;
        }
    }

    // Handle incorrect guess
    function handleIncorrectGuess() {
        mistakes = mistakes + 1;
        updateHangmanDisplay(mistakes);
        displayLives(maxMistakes - mistakes);

        if (mistakes >= maxMistakes) {
            showResult('defeat');
            isGameOver = true;
            hintBtn.disabled = true;
            revealWord(word);
        }
    }

    // Handle letter guess function
    function guessLetter(letter) {
        if (isGameOver) return;
        if (guessedLetters.includes(letter)) return;

        guessedLetters.push(letter);
        disableLetterButton(letter);

        if (isLetterInWord(letter)) {
            handleCorrectGuess(letter);
        } else {
            handleIncorrectGuess();
        }
    }
    //#endregion
    //==================================================================

    // Update global callback to point to this game's guessLetter function
    guessLetterCallback = guessLetter;

    // Setup listeners
    hintBtn.onclick = function () {
        if (isGameOver) return;
        let hintLetter = getHintLetter(word, guessedLetters);
        if (hintLetter) {
            guessLetter(hintLetter);
        }
    };
}

//#endregion
//==================================================================

//==================================================================
// AUTOSTART
//==================================================================

displayLives(6);
createTopicDropdown();
createKeyboard();
//setup event listeners
//outside playGame so they are set only once
//avoids setting and deleting multiple listeners
setupPhysicalKeyboard();
setupVirtualKeyboard();
setupNewGameBtn();
setupTopicSelect();
//start the first game (optional)
playGame();
