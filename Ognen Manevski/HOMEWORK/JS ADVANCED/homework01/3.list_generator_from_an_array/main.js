//List generator from an array
let arrayWithNames = ['John', 'Jane', 'Jim', 'Jill', 'Jack'];
let buttonForNames = document.querySelector("#generateNames");
let listForNames = document.querySelector("#names-result");

function generateNames(arr) {
    let html = "";
    for(let name of arr){
        html += `<li>${name}</li>`;
    }
    listForNames.innerHTML = html;
}

buttonForNames.addEventListener("click", function(){
    generateNames(arrayWithNames);
});


