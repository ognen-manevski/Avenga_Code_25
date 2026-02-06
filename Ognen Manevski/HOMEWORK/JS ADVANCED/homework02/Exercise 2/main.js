// api url 
const url = "https://swapi.py4e.com/api/people/1";

//selecting elements
let btn = document.getElementById("btn");
let resultDiv = document.getElementById("result");

//function to fetch data
//trying async/await
async function fetchData() {
    try {
        let response = await fetch(url);
        if (!response.ok) {
            //response.status is not in the range 200-299
            throw new Error(`HTTP error! status: ${response.status}`);
        }
        let data = await response.json();
        // console.log(data);
        displayData(data);
    } catch (err) {
        //catching the thrown error
        console.error("Error fetching data:", err);
        resultDiv.innerHTML = '<p style="color: red;">Failed to load data.</p>';
    }
}


// person stats:
//     Height
//     Weight
//     Eye color
//     Hair color

//display data
function displayData(data) {
    resultDiv.innerHTML = "";
    let html = "";
    html += `<h1>Name: ${data.name}</h1>`;
    html += `<table>`;
    html += `
    <tr>
        <td><b>Height:</b></td><td>${data.height} cm</td>
    </tr>
    <tr>
        <td><b>Weight:</b></td><td>${data.mass} kg</td>
    </tr>
    <tr>
        <td><b>Eye Color:</b></td><td>${data.eye_color}</td>
    </tr>
    <tr>
        <td><b>Hair Color:</b></td><td>${data.hair_color}</td>
    </tr>`;
    html += `</table>`;
    resultDiv.innerHTML = html;
}

//btn event
btn.addEventListener("click", fetchData);


