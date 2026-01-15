// Change the text of all paragraphs and headers with javascript

//paragraphs

let p1 = document.getElementsByClassName('paragraph')[0];
p1.textContent = "This is the new text for the first paragraph.";

let p2 = document.querySelector('.paragraph.second');
p2.textContent = "This is the new text for the second paragraph.";

//text
let text1 = p2.nextElementSibling;
text1.textContent = "This is the new text for the text element.";

//headers

let h1_1 = document.getElementById('myTitle');
h1_1.textContent = "This is the new text for the first header.";

let h1_2 = document.getElementsByTagName('h1')[1];
h1_2.textContent = "This is the new text for the second header.";

let h3 = document.getElementsByTagName('h3')[0];
h3.textContent = "This is the new text for the third header.";