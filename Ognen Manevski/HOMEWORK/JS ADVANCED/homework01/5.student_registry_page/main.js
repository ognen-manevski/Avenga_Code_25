//student registry page
//get elements
let fnameInput = document.getElementById('firstName');
let lnameInput = document.getElementById('lastName');
let ageInput = document.getElementById('age');
let emailInput = document.getElementById('email');

let formElement = document.querySelector('form');

let addBtn = document.getElementById('addBtn');
let resetBtn = document.getElementById('resetBtn');

let errorDiv = document.getElementById('error');
let resultDiv = document.getElementById('result');

//students array memory "database"
let database = [];

//student object
function Student(fName, lName, age, email) {
    this.fName = fName;
    this.lName = lName;
    this.age = age;
    this.email = email;
}

//verification function
function verifyStudent() {
    //reset
    errorDiv.innerHTML = '';
    if (fnameInput.value === '' || lnameInput.value === '' || ageInput.value === '' || emailInput.value === '') {
        errorDiv.innerHTML += `<div>All fields are required!</div>`;
    }
    if (isNaN(ageInput.value) || ageInput.value <= 0) {
        errorDiv.innerHTML += `<div>Age must be a positive number!</div>`;
    }
    if (!emailInput.value.includes('@')) {
        errorDiv.innerHTML += `<div>Email must be valid and contain "@" symbol!</div>`;
    }
}

//helper function to capitalize names
function capitalizeNames(name) {
    //name to lowercase, split by space (za iminja so space izmegju),
    //capitalize first letter of each word, join back to string
    return name.toLowerCase().trim().split(' ').map(word => word.charAt(0).toUpperCase() + word.slice(1)).join(' ').trim();
}

//student generator function
function generateStudent() {
    let student = new Student(
        capitalizeNames(fnameInput.value),
        capitalizeNames(lnameInput.value),
        ageInput.value,
        emailInput.value,
    );
    database.push(student);
}

//print the database
function printDatabase() {
    //reset
    resultDiv.innerHTML = '<ul>';
    database.forEach(student => {
        resultDiv.innerHTML += `
        <li><b>${student.fName} ${student.lName}</b> Age: ${student.age}, Email: ${student.email}</li>`;
    });
    resultDiv.innerHTML += '</ul>';
}

//click handler
function addStudentHandler() {
    verifyStudent();
    //stop if err
    if (errorDiv.innerHTML !== '') {
        return;
    }
    generateStudent();
    printDatabase();
    //reset form
    formElement.reset();
    //enable reset button
    resetBtn.disabled = false;
}

addBtn.addEventListener('click', addStudentHandler);


//reset btn
function resetStudents() {
    resultDiv.innerHTML = '';
    errorDiv.innerHTML = '';
    resetBtn.disabled = true;
}

resetBtn.addEventListener('click', resetStudents);