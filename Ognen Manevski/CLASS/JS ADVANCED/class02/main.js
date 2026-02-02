//arrays
function createArray1() {
    let arr = [];
    let first = 1;
    let last = 1000;
    for (let i = first; i <= last; i++) {
        if (i % 3 === 0) {
            arr.push(i);
        }
    }
    return arr;
}
function createArray2() {
    let arr = [];
    let first = 1;
    let last = 1000;
    for (let i = first; i <= last; i++) {
        if (i % 4 === 0) {
            arr.push(i);
        }
    }
    return arr;
}
function createArray3() {
    let arr = [];
    let first = 1;
    let last = 1000;
    for (let i = first; i <= last; i++) {
        let string = i.toString();
        if (string.endsWith('1')) {
            arr.push(i);
        }
    }
    return arr;
}
//clean arrays
function cleanArray1(arr) {
    let cleanArr = [];
    for (let item of arr) {
        if (typeof item == 'string') {
            cleanArr.push((item));
        }
    }
    return cleanArr;
}
function cleanArray2(arr) {
    let cleanArr = [];
    for (let item of arr) {
        if (typeof item == 'number' && !Number.isNaN(item)) {
            cleanArr.push((item));
        }
    }
    return cleanArr;
}
function cleanArray3(arr) {
    let cleanArr = [];
    for (let item of arr) {
        if (item || typeof item === "boolean") {
            cleanArr.push(item);
        }
    }
    return cleanArr;
}
// let test = [true, false, 12, 13, 44, 2345, "Bob", "Jill", false, undefined, 1000, null, "Jack", "", "", 99, "Greg", undefined, NaN, 1, 22];
// console.log(cleanArray3(test));


// Random color page
let colorDisplay = document.getElementById('colorDisplay');
let body = document.body;

function getRandomInt(max) {
    return Math.floor(Math.random() * max);
}

function setBgColor() {
    let colorRed = getRandomInt(256);
    let colorGreen = getRandomInt(256);
    let colorBlue = getRandomInt(256);
    let bgColor = `rgb(${colorRed}, ${colorGreen}, ${colorBlue})`;

    body.style.backgroundColor = bgColor;
    colorDisplay.textContent = bgColor;

    if ((colorRed > 200 ||
        colorGreen > 200 ||
        colorBlue > 200)) {
        colorDisplay.style.color = 'black';
    } else {
        body.style.color = 'white';
    }
}
body.onload = setBgColor;

//generate title from input

let titleBtn = document.getElementById('btn1');
let titleResult = document.getElementById('titleResult');

let colorInput = document.getElementById('color');
let fontSizeInput = document.getElementById('fontSize');
let titleTextInput = document.getElementById('titleText');

function generateTitle() {
    let titleText = titleTextInput.value;
    if (titleText.trim() === '') {
        titleResult.textContent = 'Please enter a title text.';
        return;
    }
    let color = colorInput.value;
    if (color.trim() === '') {
        titleResult.textContent = 'Please enter a color.';
        return;
    }
    let fontSize = fontSizeInput.value;
    if (fontSize.trim() === '' || isNaN(fontSize) || fontSize <= 0) {
        titleResult.textContent = 'Please enter a valid font size.';
        return;
    }

    titleResult.style.color = color;
    titleResult.style.fontSize = fontSize + 'px';
    titleResult.textContent = titleText;
}
titleBtn.addEventListener('click', generateTitle);

//Student constructor function
// Create an array with 3 students
function Student(firstName, lastName, birthYear, academy, grades) {
    this.firstName = firstName;
    this.lastName = lastName;
    this.birthYear = birthYear;
    this.academy = academy;
    this.grades = grades;
    //methods
    this.getAge = function () {
        let currentYear = new Date().getFullYear();
        return currentYear - this.birthYear;
    }
    this.getInfo = function () {
        return `This is student ${this.firstName} ${this.lastName} from the academy ${this.academy}!`;
    }
    this.gradesAverage = function () {
        let sum = 0;
        for (let grade of this.grades) {
            sum += grade;
        }
        return sum / this.grades.length;
    }
}

function createStudents() {
    let students = [];
    let student1 = new Student('John', 'Doe', 1995, 'SEDC', [8, 9, 10]);
    let student2 = new Student('Johny', 'Doee', 1996, 'Qinshift', [11, 12, 13]);
    let student3 = new Student('Johnson', 'Doeeee', 1997, 'Avenga', [14, 15, 16]);
    students.push(student1, student2, student3);
    return students;
}
//List generator from an array
let arrayWithNames = ['John', 'Jane', 'Jim', 'Jill', 'Jack'];
let buttonForNames = document.querySelector("#generateNames");
let listForNames = document.querySelector("#names-result");

function generateNamesF(arr) {
    let html = "";
    for(let name of arr){
        html += `<li>${name}</li>`;
    }
    listForNames.innerHTML = html;
}

buttonForNames.addEventListener("click", function(){
    generateNamesF(arrayWithNames);
});
//List Generator dynamically from inputs

