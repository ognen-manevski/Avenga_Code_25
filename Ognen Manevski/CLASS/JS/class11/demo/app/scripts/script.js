// let a = 10;
// let b = 20;
// let c = sum(a, b);
// let d = subtract(b, a);
// let e = multiply(a, b);
// let f = divide(b, a);


// console.log($);
let h3 = document.querySelector('#firstTitle');
let h3jq = $('#firstTitle');
// console.log(h3, h3jq);
let getByClassname = $('.innerWrapper');
let getByTagname = $('p');
// console.log(getByTagname);

h3.style.color = 'red';
h3jq.css('background-color', 'lightblue');

h3.innerText = 'This title is changed using JavaScript!';
h3jq.text('This title is changed using jQuery!');

let allElements = $('*');
let lastP = allElements.find('.wrapper').find('p').last();
lastP.css('color', 'green');

//attribute selector
let demoP = $('p[name="demo"]').css('color', 'purple');

//event listener
let btn = $('#btn');
let input = $('#username');

btn.on('click',  function(e){
    console.log(e);    
})

input.change(function(e){
    // console.log(e.target.value);
    console.log($(this).val());
});