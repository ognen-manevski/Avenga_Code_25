// api url 
const url = "https://raw.githubusercontent.com/qa-codecademy/mkwd13-04-ajs/refs/heads/main/shared_data/students.json";

//selecting elements
let btn = document.getElementById("btn");
let resultDiv = document.getElementById("result");

//function to fetch data
function fetchData() {
    fetch(url)
        .then(function (response) {
            return response.json();
        })
        .then(function (data) {
            // console.log(data);
            displayData(data);
        })
        .catch(function (error) {
            console.error("Error fetching data:", error);
            resultDiv.innerHTML = '<p style="color: red;">Failed to load data.</p>';
        });
}

//display data
function displayData(data) {
    resultDiv.innerHTML = "";
    let html = "";
    html += `<h1>Academy Name: ${data.academy}</h1>`;
    //if trainer or assistant
    if (data.trainer) {
        html += "<p>";
        html += `<b>Trainer:</b> ${data.trainer}`;
        if (data.assistant) {
            html += `<b> | Assistant:</b> ${data.assistant}`;
        }
        html += "</p>";
    }
    html += "<ul>";
    data.students.forEach(function (student) {
        html += `<li>${student}</li>`;
    });
    html += "</ul>";
    resultDiv.innerHTML = html;
}

//btn event
btn.addEventListener("click", fetchData);


