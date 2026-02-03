//movie renting app
//get elements
const movieNameInput = document.getElementById('movieName');
const searchBtn = document.getElementById('searchBtn');
const errorDiv = document.getElementById('error');
const resultDiv = document.getElementById('result');

//movies database arr
const moviesDB = [ 
    "Avatar",
    "Avengers: Endgame",
    "Titanic",
    "The Godfather",
    "The Dark Knight",
    "Pulp Fiction",
    "Forrest Gump",
    "Inception",
    "The Matrix",
    "Fight Club",
    "The Lord of the Rings: The Return of the King",
    "Interstellar"
];

//print error
function printError() {
    errorDiv.textContent = "The movie can't be rented";
}

//print result
function printResult(name) {
    resultDiv.innerHTML = `<h1>The movie ${name} can be rented!</h1>`;
}

//search fn
function searchMovie() {
    //clear previous messages
    errorDiv.textContent = "";
    resultDiv.textContent = "";

    let movieName = movieNameInput.value.trim().toLowerCase();

    //search in db
    //find method returns the first matching element or undefined
    let found = moviesDB.find(movie => movie.toLowerCase() === movieName);

    if(found) {
        printResult(found);
    } else {
        printError();
    }
}

searchBtn.addEventListener('click', searchMovie);