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
// #region 🧩 Implementation
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
    tableContainer: document.getElementById("tableContainer"),
    tableBody: document.getElementById("tableBody"),
    //display buttons
    displayCardsBtn: document.getElementById("displayCards"),
    displayTableBtn: document.getElementById("displayTable"),
}

// reset function
function reset() {
    htmlEl.cardsContainer.innerHTML = "";
    htmlEl.searchInput.value = "";
    htmlEl.tableBody.innerHTML = "";
}

// 2. implement functon to fetch data (provide fields what kind of data we need)

const url = "https://restcountries.com/v3.1/all?fields=name,capital,population,flags,region,borders,cca3";

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

// 3. implement a function to display/hide spinner
function showSpinner(show) {
    if (show) {
        htmlEl.spinner.classList.remove("d-none");
    } else {
        htmlEl.spinner.classList.add("d-none");
    }
    // htmlEl.spinner.classList.toggle("d-none");
}

// 4. implement function that will display data in cards
function createCard(country) {
    return `
        <div class="col-sm-12 col-md-6 col-lg-4 col-xl-3 pb-4" >
            <div class="card h-100 rounded-3">
                <div class="d-flex">
                    <img src="${country.flags.png}"
                        class="card-img-top"
                        alt="${country.flags.alt}">
                </div>
                <div class="card-body d-flex flex-column">
                    <h5 class="card-title">${country.name.common}</h5>
                    <p class="card-text">
                        ${country.name.common} is a country with a population of
                        <b>${formatPopulation(country.population)} citizens</b>
                        and ${formatCapitalsDisplay(country.capital)}.
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
    </div > `;
}

// helper functions
function formatPopulation(num) {
    return num.toString().split("").map(
        (n, i) => (i % 3 === 0 && i !== 0) ? `.${n}` : n
    ).join("");
}

function formatCapitalsDisplay(cap) {
    if (!cap) {
        return "the country doesnt have a capital city";
    } else if (cap.length === 1) {
        return `their capital city is <b>${cap[0]}</b>`;
    } else {
        return `their capital cities are: ${multipleCapitals(cap)}`;
    }
}

function multipleCapitals(cap) {
    let capStr = cap.map((c, i) => {
        if (i === cap.length - 1 && i !== 0) return ` and <b>${c}</b>`;
        return `<b>${c}</b>`;
    }).join(", ");
    return capStr;
}

// 5. function that will display data in table
function createTableRow(country) {
    return `
            <tr>
                <td>
                    <img src="${country.flags.png}" alt="${country.flags.alt}" class="flag-table">
                </td>
                <td>${country.name.common}</td>
                <td>${formatPopulation(country.population)}</td>
                <td>${multipleCapitals(country.capital)}</td>
                <td>
                    <a href="https://en.wikipedia.org/wiki/${country.name.common}"
                        class="btn btn-primary mt-auto" target="_blank">
                        More
                        <span class="material-symbols-outlined wiki-icon">
                            arrow_right_alt
                        </span>
                    </a>
                </td>
            </tr>
            `;
}

// 6. implement 5 event listeners for the 5 btns
htmlEl.searchBtn.addEventListener("click", search);
htmlEl.searchInput.addEventListener("keypress", (e) => e.key === "Enter" ? search() : null);
htmlEl.allEUBtn.addEventListener("click", getAllEU);
htmlEl.resetBtn.addEventListener("click", reset);
htmlEl.allNeighborsBtn.addEventListener("click", getNeighbors);
htmlEl.macedoniaBtn.addEventListener("click", getMacedonia);

// 6.1 search, reset, all from europe, all neighbors of Macedonia, Macedonia

// 6.1.1 search function
function search() {
    let url = createSearchUrl();
    reset();
    showSpinner(true);
    if (!url) {
        showSpinner(false);
        return;
    }
    getData(url)
        .then(countries => {
            countries.forEach(country => {
                htmlEl.cardsContainer.innerHTML += createCard(country);
                htmlEl.tableBody.innerHTML += createTableRow(country);
            });
            showSpinner(false);
        });
}

//search helpers
function createSearchUrl() {
    const value = formatSearchValue(htmlEl.searchInput.value);
    if (!value) {
        return;
    }
    return `https://restcountries.com/v3.1/name/${value}?fields=name,capital,population,flags,region,borders`;
}

function formatSearchValue(value) {
    return value.toLowerCase().trim().split(" ").join("%20");
}

// 6.1.2 get all countries from Europe
function getAllEU() {
    reset();
    showSpinner(true);
    getData(url)
        .then(countries => {
            let filteredC = countries.filter(c => c.region === "Europe");
            filteredC.forEach(country => {
                htmlEl.cardsContainer.innerHTML += createCard(country);
                htmlEl.tableBody.innerHTML += createTableRow(country);
            })
            showSpinner(false);
        });
}

// 6.1.3 get neighbors of Macedonia
function getNeighbors() {
    reset();
    showSpinner(true);
    getData(url)
        .then(countries => {
            let neighborsCodes = getMacedoniaNeighbors(countries);
            let neighbors = getCountriesByCodes(countries, neighborsCodes);
            neighbors.forEach(country => {
                htmlEl.cardsContainer.innerHTML += createCard(country);
                htmlEl.tableBody.innerHTML += createTableRow(country);
            })
            showSpinner(false);
        });
}

//helpers for get neighbors
function getMacedoniaNeighbors(data) {
    let macedonia = data.find(c => c.name.common === "North Macedonia");
    return macedonia.borders;
}

function getCountriesByCodes(data, codes) {
    return data.filter(c => codes.includes(c.cca3));
}

// 6.1.4 Macedonia function
function getMacedonia() {
    reset();
    showSpinner(true);
    getData(url)
        .then(countries => {
            let filteredC = countries.filter(c => c.name.common === "North Macedonia");
            filteredC.forEach(country => {
                htmlEl.cardsContainer.innerHTML += createCard(country);
                htmlEl.tableBody.innerHTML += createTableRow(country);
            })
            showSpinner(false);
        });
}

// 7. implement constructior function with props only needed for the cards
// (flag, name, population, capital, wiki link)
// ^ ne mi treba

// Handle API errors and empty results gracefully
// ^ done vo fetch

// bonus: table/cards switcher
function displaySwitcher(e) {
    htmlEl.cardsContainer.classList.toggle("d-none");
    htmlEl.tableContainer.classList.toggle("d-none");
    htmlEl.displayCardsBtn.classList.toggle("btn-primary");
    htmlEl.displayCardsBtn.classList.toggle("btn-outline-secondary");
    htmlEl.displayTableBtn.classList.toggle("btn-primary");
    htmlEl.displayTableBtn.classList.toggle("btn-outline-secondary");
}
htmlEl.displayCardsBtn.addEventListener("click", displaySwitcher);
htmlEl.displayTableBtn.addEventListener("click", displaySwitcher);

// #endregion
//----------------------------------------------------------------------
