//reminder app
//get elements
const titleInput = document.getElementById('title');
const priorityInput = document.getElementById('priority');
const colorInput = document.getElementById('color');
const textInput = document.getElementById('description');
const form = document.querySelector('form');
const addBtn = document.getElementById('addBtn');
const showBtn = document.getElementById('showBtn');
const errorDiv = document.getElementById('error');
const resultDiv = document.getElementById('result');

//title memory
const titleHover = "You don't have any reminders";

//database array
let reminders = [];

//id tracker
let uniqueID = 0;

//helper text contrast
function getContrastYIQ(hexcolor) {
    hexcolor = hexcolor.replace("#", "");
    let r = parseInt(hexcolor.substr(0, 2), 16);
    let g = parseInt(hexcolor.substr(2, 2), 16);
    let b = parseInt(hexcolor.substr(4, 2), 16);
    let yiq = ((r * 299) + (g * 587) + (b * 114)) / 1000;
    return (yiq >= 128) ? 'black' : 'white';
}

//reminder obj
function Reminder(title, priority, color, text, id) {
    this.title = title;
    this.priority = priority;
    this.color = color;
    this.text = text;
    this.id = id;
    //print HTML
    this.getHTML = function () {
        return `<div style="background-color: ${this.color}; color: ${getContrastYIQ(this.color)};" class="reminder">
                    <h3>${this.title}</h3>
                    ${this.priority ? `<p class="priority">Priority: ${this.priority}</p>` : ''}
                    ${this.text ? `<p class="body">${this.text}</p>` : ''}
                    <div class="delete" data-id="${this.id}">x</div>
                </div>`;
    }
}

//input validation
function validateInput() {
    if (titleInput.value === '') {
        errorDiv.textContent = 'Title is required.';
    }
}

//add reminder click handler
function addReminder() {

    //clear previous errors
    errorDiv.textContent = '';

    //check for errors
    validateInput();
    if (errorDiv.textContent !== '') {
        return;
    }

    //get values
    let title = titleInput.value;
    let priority = priorityInput.value;
    let color = colorInput.value;
    let text = textInput.value;

    //create reminder
    let newReminder = new Reminder(title, priority, color, text, uniqueID);
    uniqueID++;

    //add to database
    reminders.push(newReminder);

    //clear inputs
    form.reset();
    
    //enable show button
    checkReminders_for_DisableBtn();
}
addBtn.addEventListener('click', addReminder);

//show reminders click handler
function showReminders() {
    //clear previous results
    resultDiv.innerHTML = '';
    //display all reminders
    reminders.forEach(reminder => {
        resultDiv.innerHTML += reminder.getHTML();
    });
}
showBtn.addEventListener('click', showReminders);

//delete reminder click handler
function deleteReminder(e) {
    if (e.target.classList.contains('delete')) {
        let idToDelete = parseInt(e.target.getAttribute('data-id'));
        //remove from database
        reminders = reminders.filter(reminder => reminder.id !== idToDelete);
        //refresh display
        showReminders();
        checkReminders_for_DisableBtn();
    }
}
resultDiv.addEventListener('click', deleteReminder);


//check reminder array to disable show button if empty
function checkReminders_for_DisableBtn() {
    if (reminders.length === 0) {
        showBtn.disabled = true;
        showBtn.setAttribute('title', titleHover);
    } else {
        showBtn.disabled = false;
        showBtn.removeAttribute('title');
    }
}