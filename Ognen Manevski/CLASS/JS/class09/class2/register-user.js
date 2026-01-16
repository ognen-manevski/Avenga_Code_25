let resultsP = document.getElementById("paragraph");

document.getElementById("btn").addEventListener("click", registerUser);

function getValues() {
    let inputs = document.getElementsByTagName("input");
    let loginForm = {};
    for (let input of inputs) {
        loginForm[input.name] = input.value;
    }
    return loginForm;
}

function registerUser() {
    let userDataArr = getValues();
    resultHtml = '';
    for (let key in userDataArr) {
        resultHtml += `<strong>${key}:</strong> ${userDataArr[key]} <br>`;
    }
    resultsP.innerHTML = resultHtml;
}