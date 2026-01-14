let main = document.getElementById('main');
let text = main.textContent;
// console.log(text);
let text1 = main.innerText;
// console.log(text1);

let h1 = main.firstElementChild;
h1.innerText = "DOM Manipulation";
h1.innerText += " with JS";

//changing and adding code
main.innerHTML += '<p>This is a paragraph</p>'; //will add as HTML
