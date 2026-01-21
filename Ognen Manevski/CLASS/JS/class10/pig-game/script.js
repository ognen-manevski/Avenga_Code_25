// #region selecting elements
//buttons
const newGameBtn = document.querySelector('.btn-new');
const rollDiceBtn = document.querySelector('.btn-roll');
const holdBtn = document.querySelector('.btn-hold');
//scores
const playerOneScoreEl = document.getElementById('score-0');
const playerTwoScoreEl = document.getElementById('score-1');
const playerOneCurrentScoreEl = document.getElementById('current-0');
const playerTwoCurrentScoreEl = document.getElementById('current-1');
//player panels
const playerOnePanel = document.querySelector('.player-0-panel');
const playerTwoPanel = document.querySelector('.player-1-panel');
//winning score input
const winningScoreInput = document.querySelector('.winningScore');
//is game active
let isGameActive = false;
//#endregion

// #region global variables
let gameWinningScore = 10;
let playerOneScore = 0;
let playerTwoScore = 0;
let roundScore = 0;
let activePlayer = 0; //0 -> player 1; 1 -> player 2
//#endregion

// #region functions
//new game function
function newGame() {
    isGameActive = true;
    buttonsOnOff(false);
    winningScoreInput.disabled = false;
    //reset memory
    playerOneScore = 0;
    playerTwoScore = 0;
    roundScore = 0;
    activePlayer = 0;
    //reset html
    playerOneScoreEl.textContent = '0';
    playerTwoScoreEl.textContent = '0';
    playerOneCurrentScoreEl.textContent = '0';
    playerTwoCurrentScoreEl.textContent = '0';
    playerOnePanel.classList.remove('winner');
    playerTwoPanel.classList.remove('winner');
}
//roll dice function
function rollDice() {
    winningScoreInput.disabled = true;
    if (!isGameActive) {
        return;
    }
    //roll dice
    let dice1 = Math.floor(Math.random() * 6) + 1;
    let dice2 = Math.floor(Math.random() * 6) + 1;
    //display dice
    document.querySelector('.dice').src = `./dice/dice-${dice1}.png`;
    document.querySelector('.dice2').src = `./dice/dice-${dice2}.png`;
    //lose turn
    if (dice1 !== 1 && dice2 !== 1) {
        roundScore += dice1 + dice2;
        if (activePlayer === 0) {
            playerOneCurrentScoreEl.textContent = roundScore;
        } else {
            playerTwoCurrentScoreEl.textContent = roundScore;
        }
    } else {
        nextPlayer();
    }
}
//hold function
function hold() {
    if (!isGameActive) {
        return;
    }
    if (activePlayer === 0) {
        playerOneScore += roundScore;
        playerOneScoreEl.textContent = playerOneScore;
        checkWinner();
        nextPlayer();
    } else {
        playerTwoScore += roundScore;
        playerTwoScoreEl.textContent = playerTwoScore;
        checkWinner();
        nextPlayer();
    }
}
//next player function
function nextPlayer() {
    //reset round score
    roundScore = 0;
    //update current score in html
    if (activePlayer === 1) {
        playerTwoCurrentScoreEl.textContent = roundScore;
    } else {
        activePlayer = 0;
        playerOneCurrentScoreEl.textContent = roundScore;
    }
    document.querySelector(`.player-${activePlayer}-panel`)
        .classList.remove('active');
    //switch active player
    activePlayer = activePlayer === 1 ? 0 : 1;
    //if(activePlayer === 1) {
    //    activePlayer = 0;
    //} else {
    //    activePlayer = 1;
    //}
    document.querySelector(`.player-${activePlayer}-panel`)
        .classList.add('active');
}
//check winner function
function checkWinner() {
    if (playerOneScore >= gameWinningScore) {
        isGameActive = false;
        playerOnePanel.classList.add('winner');
        alert('Player 1 is the Winner!');
        buttonsOnOff(true);
        return;
    }
    if (playerTwoScore >= gameWinningScore) {
        isGameActive = false;
        playerTwoPanel.classList.add('winner');
        alert('Player 2 is the Winner!');
        buttonsOnOff(true);
        return;
    }
}
//buttons on/off function
function buttonsOnOff(state) {
    if (!state) {
        rollDiceBtn.disabled = false;
        holdBtn.disabled = false;
        rollDiceBtn.addEventListener('click', rollDice);
        holdBtn.addEventListener('click', hold);
        winningScoreInput.disabled = true;
        return;
    } else {
        rollDiceBtn.disabled = true;
        holdBtn.disabled = true;
        rollDiceBtn.removeEventListener('click', rollDice);
        holdBtn.removeEventListener('click', hold);
        winningScoreInput.disabled = false;
        return;
    }
}
//get winning score input function
function getWinningScore() {
    const input = toNumber(winningScoreInput.value);
    if (input) {
        return input;
    } else {
        return gameWinningScore;
    }
}
//convert to number function
function toNumber(value) {
    const number = parseInt(value); 
    if (isNaN(number)) {
        return null;
    } else {
        return number;
    }   
}
//#endregion

// #region event listeners
newGameBtn.addEventListener('click', newGame);
//get score input on change
winningScoreInput.addEventListener('change', function () {
    const inputScore = getWinningScore();
    gameWinningScore = inputScore;
});
//#endregion

//start the game
newGame();