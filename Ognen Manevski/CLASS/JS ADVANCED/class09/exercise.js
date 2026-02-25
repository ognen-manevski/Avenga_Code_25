//al lcountries -> capital population
const url = "https://restcountries.com/v3.1/all?fields=name,capital,population,borders";

async function getData(url) {
    try {
        let data = await fetch(url);
        let json = await data.json();
        return json;
    } catch (err) {
        console.log(err);
    } finally {
        console.log("Done :D");
    }
};


// helper functions 

async function showAll() {
    let data = await getData(url);
    data.forEach(el => {
        console.log(`Country: ${el.name.common} , Capital: ${el.capital[0]} , Population: ${el.population}`);
    });
}


async function getMacedonia() {
    let data = await getData(url)
    let mk = data.find(el => el.name.common === "North Macedonia");
    console.log(`Country: ${mk.name.common} , Capital: ${mk.capital[0]} , Population: ${mk.population}`);
}

async function getNeighbors(country){
    let data = await getData(url)
    data.filter(el => {
        if (el.name.common === country){
            let neighbors = el.borders.join(", ");
            console.log(`The neighbors of ${country} are: ${neighbors}.`);
        }
    })
}

// showAll();
getMacedonia();
getNeighbors("North Macedonia");




