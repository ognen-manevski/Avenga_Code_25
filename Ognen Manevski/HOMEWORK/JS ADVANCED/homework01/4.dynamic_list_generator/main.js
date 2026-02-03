//List Generator dynamically from inputs
let colorInput = document.getElementById('color');
let fontSizeInput = document.getElementById('fontSize');
let itemsInput = document.getElementById('items');

let generateBtn = document.getElementById('btn');
let resetBtn = document.getElementById('resetBtn');
let errorDiv = document.getElementById('error');
let resultDiv = document.getElementById('result');

function generateList() {
    //reset err
    errorDiv.innerHTML = '';

    //get values
    let color = colorInput.value;
    let fontSize = fontSizeInput.value;
    let itemsText = itemsInput.value;

    //validation
    if (!color || !fontSize || !itemsText) {
        errorDiv.innerHTML = `<p style="color: red;">Please fill in all fields.</p>`;
        return;
    }
    //comma validation
    if (!itemsText.includes(',')) {
        errorDiv.innerHTML = `<p style="color: red;">Please separate items with commas.</p>`;
        return;
    }

    //split items by comma (creates an array)
    let items = itemsText.split(',');

    //create list element
    let newHTML = `<ul style="color: ${color}; font-size: ${fontSize}px;">`;
    items.forEach(item => {
        //trim za spaces
        newHTML += `<li>${item.trim()}</li>`;
    });
    newHTML += "</ul>";

    // add the new list
    resultDiv.innerHTML += newHTML;

    //enable reset button
    resetBtn.disabled = false;
}

generateBtn.addEventListener('click', generateList);

function resetLists() {
    resultDiv.innerHTML = '';
    errorDiv.innerHTML = '';
    resetBtn.disabled = true;
}

resetBtn.addEventListener('click', resetLists);