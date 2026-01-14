let students = ["Bob Bobsky", "Jill Cool", "John Doe", "Jane Sky"];
let subjects = ["Math", "English", "Science", "Sport"];
let grades = ["A", "B", "A", "C"];

let myApp = document.getElementById("app");
let title = myApp.firstElementChild;
let content = title.nextElementSibling;

function printGrades(subjects, grades, element) {
    //reset
    element.innerHTML = "";
    content.innerHTML += `<h2>Your grades are:</h2>`;
    element.innerHTML += `<ul>`;
    for (let i = 0; i < subjects.length; i++) {
        element.innerHTML += `<li>${subjects[i]} : ${grades[i]}</li>`;
    }
    element.innerHTML += `</ul>`;
};

function printStudents(students, element) {
    //reset
    element.innerHTML = "";
    content.innerHTML += `<h2>Your students are:</h2>`;
    element.innerHTML += `<ol>`;
    for (let student of students) {
        element.innerHTML += `<li>${student}</li>`;
    }
    element.innerHTML += `</ol>`;
};


function academyPanel(role, name) {
    if (role === "student") {
        title.innerHTML += `
        <h1>
            <b>
                Hello there, ${name}
            </b>
        </h1>
        <p>Welcome to your student page</p>
        `;
        printGrades(subjects, grades, content);
    }
    else if (role === "teacher") {
        title.innerHTML += `
        <h1>
            <b>
                Welcome to the academy, ${name}
            </b>
        </h1>
        <p>Welcome to your teacher page</p>
        `;
        printStudents(students, content);
    } else {
        title.innerHTML += '<h1><b>Your Login was Unsucessful</b></h1>';
        title.innerHTML += '<p>Please try again!</p>';
    }
}

let role = prompt("Enter your role (student/teacher):").toLowerCase();
let userName = prompt("Enter your name:");

academyPanel(role, userName);