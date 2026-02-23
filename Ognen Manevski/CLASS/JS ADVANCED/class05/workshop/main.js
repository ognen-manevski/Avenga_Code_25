//----------------------------------------------------------------------
// #region Workshop
//----------------------------------------------------------------------

// Build your app 🥽
// CountrySearch 🌍🌎🌏
// CountrySearch is an application that is meant to search for countries and get countries for them in real-time.
// The application is very simple. It only has one functionality: Search and show the countries in a table

// Requirements
// There should be one search input to input the name or partial name of a country
// There should be a button for search to initiate
// When the button is clicked, a list of cards shows the possible answers
// The list shows:
// Flag
// Name
// Population
// Capital
// Link to the country's Wikipedia page "Open on Wikipedia" (https://en.wikipedia.org/wiki/< country_name>)
// The API for countries is: https://restcountries.com/
// Read the API documentation to figure out how to call for the countries
// Extra requirements
// Add three buttons on top of the list with the following functionality:

// Button 1: Get all countries in Europe
// Button 2: Get all countries that are neighbors of Macedonia
// Button 3: Get Macedonia

// #endregion
//----------------------------------------------------------------------

//----------------------------------------------------------------------
// #region 🧩 Code-Level Example Copilot Instructions (Paste in JS File as Comments)
//----------------------------------------------------------------------

// 1. select all the html elements needed

let htmlEl = {
    //searchbar
    searchInput: document.getElementById("searchInput"),
    searchBtn: document.getElementById("searchBtn"),
    resetBtn: document.getElementById("resetBtn"),
    //filters
    allEUBtn: document.getElementById("allEU"),
    allNeighborsBtn: document.getElementById("allNeighbors"),
    macedoniaBtn: document.getElementById("macedonia"),
    //spinner
    spinner: document.getElementById("spinner"),
    //results
    cardsContainer: document.getElementById("cardsContainer"),
}

// 2. implement functon to fetch data (provide fields what kind of data we need)
// # Get all countries (filtered by fields)
// https://restcountries.com/v3.1/all?fields=name,capital,currencies
// # Get country by name
// https://restcountries.com/v3.1/name/peru
// # Get country by code
// https://restcountries.com/v3.1/alpha/co
// # Filter response fields
// https://restcountries.com/v3.1/{service}?fields={field},{field},{field}
const url = " https://restcountries.com/v3.1/all?fields=name,capital,population,flags,region";

function getData(url) {
    return fetch(url)
        .then(res => res.json())
        .catch(err => {
            console.log(err);
            showSpinner(false);
            htmlEl.cardsContainer.innerHTML = `
            <div class="px-3 w-100" role="alert">
                <p class="alert alert-danger text-center">
                    An error occurred while fetching data.
                </p>
            </div>`;
        });
}

function createCard(country) {
    return `
    <div class="col-sm-12 col-md-6 col-lg-4 col-xl-3 pb-4">
        <div class="card h-100">
            <img src="${country.flags.png}"
                class="card-img-top m-2 border border-body"
                alt="${country.flags.alt}">
            <div class="card-body d-flex flex-column">
                <h5 class="card-title">${country.name.common}</h5>
                <p class="card-text">
                    ${country.name.common} is a country with a population of <b>${formatPopulation(country.population)} citizens</b>
                    and their capital is <b>${country.capital[0]}</b>.
                </p>
                <a href="https://en.wikipedia.org/wiki/${country.name.common}"
                    class="btn btn-primary mt-auto" target="_blank">
                    Open on Wikipedia
                    <span class="material-symbols-outlined wiki-icon">
                        arrow_right_alt
                    </span>
                </a>
            </div>
        </div>
    </div>`;
}

function formatPopulation(num) {
    return num.toString().split("").map(
        (n, i) => (i % 3 === 0 && i !== 0) ? `,${n}` : n
    ).join("");
}

// 3. implement a function to display/hide spinner
function showSpinner(show) {
    if (show) {
        htmlEl.spinner.classList.remove("d-none");
    } else {
        htmlEl.spinner.classList.add("d-none");
    }
    // htmlEl.spinner.classList.toggle("d-none");
}
// showSpinner(true);

// 4. implement function that will display data in cards



// 5. function that will display data in table



// 6. implement 5 event listeners for the 5 btns

function reset() {
    htmlEl.cardsContainer.innerHTML = "";
    htmlEl.searchInput.value = "";
}

function search(e) {
    e.preventDefault();
    const value = htmlEl.searchInput.value;
    console.log(value);
}

function getAllEU(e) {
    e.preventDefault();
    reset();
    showSpinner(true);
    getData(url)
        .then(countries => {
            let filteredC = countries.filter(c => c.region === "Europe");
            filteredC.forEach(country => {
                htmlEl.cardsContainer.innerHTML += createCard(country);
            })
            showSpinner(false);
        });
}



htmlEl.searchBtn.addEventListener("click", search);
htmlEl.resetBtn.addEventListener("click", reset);

htmlEl.allEUBtn.addEventListener("click", getAllEU);

htmlEl.allNeighborsBtn.addEventListener("click", () => console.log("neighbors"));

htmlEl.macedoniaBtn.addEventListener("click", () => console.log("macedonia"));




// 6.1 search, reset, all from europe, all neighbors of Macedonia, Macedonia
// 7. implement constructior function with props only needed for the cards
// (flag, name, population, capital, wiki link)


//

// Create a function that fetches countries based on search input
// Create a function that renders country cards into the DOM
// Add event listener for search button
// Add event listener for 'Europe' button
// Add event listener for 'Macedonia' button
// Add event listener for 'Neighbors of Macedonia' button
// Handle API errors and empty results gracefully

// #endregion
//----------------------------------------------------------------------

//----------------------------------------------------------------------
// #region HTML
//----------------------------------------------------------------------

// card template
/*<div class="col-sm-12 col-md-6 col-lg-4 pb-4">
    <div class="card">
        <img src="..." class="card-img-top" alt="...">
            <div class="card-body">
                <h5 class="card-title">Card title</h5>
                <p class="card-text">Lorem Ipsum</p>
                <a href="#" class="btn btn-primary">Wikipedia Link</a>
            </div>
    </div>*/

// #endregion
//----------------------------------------------------------------------


