//generate title from input

let titleBtn = document.getElementById('btn1');
let titleResult = document.getElementById('titleResult');

let colorInput = document.getElementById('color');
let fontSizeInput = document.getElementById('fontSize');
let titleTextInput = document.getElementById('titleText');

function generateTitle() {
    //reset title style
    titleResult.style.color = 'red';
    titleResult.style.fontSize = '16px';

    //get values
    let titleText = titleTextInput.value;
    let color = colorInput.value;
    let fontSize = fontSizeInput.value;

    //checks
    if (titleText.trim() === '') {
        titleResult.textContent = 'Please enter a title text.';
        return;
    }
    if (color.trim() === '') {
        titleResult.textContent = 'Please enter a color.';
        return;
    }
    if (fontSize.trim() === '' || isNaN(fontSize) || fontSize <= 0) {
        titleResult.textContent = 'Please enter a valid font size.';
        return;
    }

    //apply css
    titleResult.style.color = color;
    titleResult.style.fontSize = fontSize + 'px';
    titleResult.textContent = titleText;
}
titleBtn.addEventListener('click', generateTitle);
