// console.log(document);

//selecting by id
let myHeader = document.getElementById('myTitle');
// console.log(myHeader);
// console.log(myHeader.innerText);

//selecting by class
let myParagraphs = document.getElementsByClassName('myParagraph');
let secondParagraph = myParagraphs[1];

//selecting by tag name
let myParagraphsByTag = document.getElementsByTagName('p');
let myText = document.getElementsByTagName('text');
// console.log(myText[0]);


//selecting by query selector
let myParagraphQS = document.querySelector('.myParagraph');
let myParagraphsQS = document.querySelectorAll('.myParagraph');
let main = document.querySelector('#main');
// console.log(myParagraphsQS);

//finding sibling elements
//properties:
// .children
// .firstElementChild
// .lastElementChild
// .nextElementSibling
// .previousElementSibling
// .parentElement

let pTag = document.getElementsByClassName('myParagraph')[0];
let ptagSibling = pTag.previousElementSibling;
// console.log(ptagSibling);
let pTagParent = pTag.parentElement;
let pTagChildren = pTagParent.children;
let pTagFirstChild = pTagParent.firstElementChild;

let pTagMyParagraph = main
    .firstElementChild
    .lastElementChild;

//selecting through a selected element
main.querySelector('p')
