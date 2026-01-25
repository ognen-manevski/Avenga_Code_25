// Exercise 1
//     Call the StarWars api for the first person
//     Link: https://swapi.dev/api/people/1
//     Print the name, hight and mass on the screen
// Ex: Name: Luke Skywalker, Height: 172, Mass: 77
// Use JQuery to solve this exercise

// #region response example
// HTTP 200 OK
// Content-Type: application/json
// Vary: Accept
// Allow: GET, HEAD, OPTIONS
// {
//     "name": "Luke Skywalker", 
//     "height": "172", 
//     "mass": "77", 
//     "hair_color": "blond", 
//     "skin_color": "fair", 
//     "eye_color": "blue", 
//     "birth_year": "19BBY", 
//     "gender": "male", 
//     "homeworld": "https://swapi.dev/api/planets/1/", 
//     "films": [
//         "https://swapi.dev/api/films/1/", 
//         "https://swapi.dev/api/films/2/", 
//         "https://swapi.dev/api/films/3/", 
//         "https://swapi.dev/api/films/6/"
//     ], 
//     "species": [], 
//     "vehicles": [
//         "https://swapi.dev/api/vehicles/14/", 
//         "https://swapi.dev/api/vehicles/30/"
//     ], 
//     "starships": [
//         "https://swapi.dev/api/starships/12/", 
//         "https://swapi.dev/api/starships/22/"
//     ], 
//     "created": "2014-12-09T13:50:51.644000Z", 
//     "edited": "2014-12-20T21:17:56.891000Z", 
//     "url": "https://swapi.dev/api/people/1/"
// }
// #endregion

//apli url const
const apiUrl = 'https://swapi.dev/api/people/';

//people count
const peopleCount = 82;

//selecting elements
let numberInput = $('#number');
let button = $('#btn');
let resultDiv = $('#result');

//function to fetch data
function fetchStarWarsData(number) {
    $.ajax({
        url: apiUrl + number + '/',
        method: 'GET',
        success: handleSuccess, //we dont pass data here, jquery does it automatically
        error: handleError
    });
}

//helper f. to format key display names
function formatKeyName(key) {
    //capitalize and replace underscore with space
    return key.charAt(0).toUpperCase() + key.slice(1).replace('_', ' ');
}

//helper success function to handle data
function handleSuccess(data) {
    //create person object
    function Person(data) {
        this.name = data.name;
        this.height = data.height;
        this.mass = data.mass;
        this.hair_color = data.hair_color;
        this.skin_color = data.skin_color;
        this.eye_color = data.eye_color;
        this.birth_year = data.birth_year;
        this.gender = data.gender;
    }
    let person = new Person(data);
    //displaying lerson data list
    let htmlToDisplay = "<ul>";
    for (let key in person) {
        htmlToDisplay += `<li><strong>${formatKeyName(key)}:</strong> ${person[key]}</li>`;
    }
    htmlToDisplay += "</ul>";
    resultDiv.html(htmlToDisplay);
}

//handle error function
function handleError() {
    resultDiv.html('<h3 style="color:red;">Error fetching data from the API.</h3>');
}


//get number value and validate
function validateNumber(){
    let number = numberInput.val();
    number = parseInt(number);
    number = Math.floor(number);
    if(isNaN(number) || number < 1 || number > peopleCount){
        resultDiv.html('<h3 style="color:red;">Please enter a valid number between 1 and ' + peopleCount + '.</h3>');
        return null;
    }
    return number;
}

//button click function
function buttonClicked(){
    //reset result div
    resultDiv.html('');
    //get and validate number
    let number = validateNumber();
    if(number === null){
        return;
    }
    //fetch data
    fetchStarWarsData(number);
}

//btn click event
button.on('click', buttonClicked);