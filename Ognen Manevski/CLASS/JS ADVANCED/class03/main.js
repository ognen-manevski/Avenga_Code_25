let studentJson = `{
    "name": "Ognen",
    "assistant": "Vscode",
    "students": [
        "Mario",
        "Dimitar",
        "Ognen",
        "Damjan"
    ],
    "academy": "Avenga Academy"
}`;

// console.log(studentJson);

let studentObject = JSON.parse(studentJson);
// console.log(studentObject);
// console.log(studentObject.students[0]);

studentObject.age = 30;

let newStudentString = JSON.stringify(studentObject);
// console.log(newStudentString);

// get data from api using plain js
// (the very old method)
document.getElementById("sendRequest")
    .addEventListener("click", function () {
        let xhr = new XMLHttpRequest();
        xhr.onload = function () {
            console.log("request is sent!");
            // 2xx status codes are successful responses
            if (xhr.status >= 200 && xhr.status < 300) {
                console.log("request successful!");
                //response is a property of the xhr object and it is a string
                let objectResponse = JSON.parse(xhr.response);
                console.log(objectResponse);
            } else {
                //responseText is a property of the xhr object and it is a string
                console.log(xhr.responseText);
            }
        }
        // open method takes 3 parameters: method, url, async (optional)
        xhr.open("GET", "https://raw.githubusercontent.com/qa-codecademy/mkwd13-04-ajs/refs/heads/main/shared_data/students.json");
        xhr.send();
    });
//open -> send -> onload

// using JQuery AJAX
$("#sendRequestJquery")
    .on("click", function () {
        $.ajax({
            url: "https://raw.githubusercontent.com/qa-codecademy/mkwd13-04-ajs/refs/heads/main/shared_data/students.json",
            success: function (data) {
                console.log("request successful!");
                let dataObject = JSON.parse(data);
                console.log(dataObject);
            },
            error: function (err) {
                console.log(err);
            }
        })
    });

//using plain JS with fetch()
document.getElementById("sendRequestFetch")
    .addEventListener("click", function () {
        fetch("https://jsonplaceholder.typicode.com/todos")
            .then(function (response) {
                // console.log(response);
                //.json() is a method from the response object
                return response.json();                
            })
            .then(function (data) {
                // console.log(data);
                let list = document.getElementById("result");
                list.innerHTML = "";
                for (const todo of data) {
                    // todo.currentTime = new Date().getSeconds();
                    list.innerHTML += `<li>${todo.title} | Completed: ${todo.completed} - ${todo.currentTime}</li>`;
                }               
            })
            .catch(function (err) {
                console.log(err);
            })
    });



