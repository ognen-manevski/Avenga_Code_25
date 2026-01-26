let baseUrl = "https://jsonplaceholder.typicode.com/";

let btn = document.getElementById("btn");

btn.addEventListener("click", fetchFunction);

function fetchFunction() {
    fetch(baseUrl + "todos/")
    .then(function(response){
        let json = response.json();
        return json;        
    })
    .then(function(data){
        console.log(data);
    })
    .catch(function(error){
        console.log(error);
    });
    
}