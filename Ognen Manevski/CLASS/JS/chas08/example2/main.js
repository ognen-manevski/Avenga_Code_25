//first div
let firstDiv = document.getElementById('first');

//all paragraphs
let allParagraphs = document.getElementsByTagName('p');

//the last div
let lastDiv = document.getElementsByTagName('div')[2];

//header 3 in the last div
let header3 = document.querySelector('h3');

//header 1 in the last div
let lastHeader1 = document.querySelectorAll('h1')[1];

//get the text from the first paragraph in the second div
let text1 = document.querySelector('.paragraph.second');

//add the word text to the text element in the second div
let secondDiv = document.getElementsByTagName('div')[1];
let secondDivText = secondDiv.getElementsByTagName('text')[0];
secondDivText.innerText += " text";


//change th etext of the header1 in the last div
lastHeader1.innerText = "This is the new text for the second h1";

//change the test of the header 3 in the last div
header3.innerText = "This is the new text for the h3";

//test
console.log(firstDiv);
console.log(allParagraphs);
console.log(lastDiv);
console.log(header3);
console.log(lastHeader1);
console.log(text1);