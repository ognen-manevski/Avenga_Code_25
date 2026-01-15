// Create a recipe page from inputs

//     Ask the user for the name of the recipe
//     Ask the user how many ingredients do we need for the recipe
//     Ask the user for the name of every ingredient
//     Print the name of the recipe in the HTML as heading element, ex: h1-h6
//     Print all ingredients as an unordered list in the HTML
//     Extra: Use a table if you want to be fancy :)

let startBtn = document.getElementById("start-btn");
startBtn.addEventListener("click", createRecipe);

let listDiv = document.getElementById("list-div");
let tableDiv = document.getElementById("table-div");

function askForName() {
    let recipeName = prompt("Enter the name of the recipe:");
    return recipeName;
};

function askForIngredientsCount() {
    let count = parseInt(prompt("How many ingredients do we need for the recipe?"));
    return count;
};

function askForIngredients(count) {
    let ingredients = [];

    for (let i = 0; i < count; i++) {
        let ingredient = prompt(`Enter the name of ingredient ${i + 1}:`);
        ingredients.push(ingredient);
    }
    return ingredients;
};

//Print as a LIST
function printRecipeList(recipeName, ingredients) {
    //reset
    listDiv.innerHTML = "";

    //heading
    listDiv.innerHTML += `<h2>${recipeName}</h2>`;

    //list
    listDiv.innerHTML += `<ul>`;
    for (let i = 0; i < ingredients.length; i++) {
        listDiv.innerHTML += `<li>Ingredient ${i + 1}: ${ingredients[i]}</li>`;
    }
    listDiv.innerHTML += `</ul>`;
};

//Print as a TABLE
function printRecipeTable(recipeName, ingredients) {
    //reset
    tableDiv.innerHTML = "";

    //build table string
    //because innerHTML is buggy, we build the whole table as a string first
    //and then inject it as a whole
    let tableHTML_string = `
    <table border="1">
        <thead>
            <tr>
                <th colspan="2">${recipeName}</th>
            </tr>
            <tr>
                <th>Ingredient No.</th>
                <th>Ingredient Name</th>
            </tr>
        </thead>
        <tbody>`;

    //table data
    for (let i = 0; i < ingredients.length; i++) {
        tableHTML_string += `
            <tr>
                <td>${i + 1}</td>
                <td>${ingredients[i]}</td>
            </tr>`;
    }
    
    tableHTML_string += `
        </tbody>
    </table>`;

    //add to DOM
    tableDiv.innerHTML = tableHTML_string;
};

//main function
function createRecipe() {
    //get data
    let recipeName = askForName();
    let ingredientsCount = askForIngredientsCount();
    let ingredients = askForIngredients(ingredientsCount);

    //print
    printRecipeList(recipeName, ingredients);
    printRecipeTable(recipeName, ingredients);
};