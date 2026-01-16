document
    .getElementById("parent")
    .addEventListener(
        "click",
        function () {
            console.log("Parent Clicked - Capturing");
        },
        true
    );


document
    .getElementById("child")
    .addEventListener(
        "click",
        function (e) {
            // e.stopPropagation();
            console.log("Child Clicked - Capturing");
        }
    );


// test

let parentResult = document.getElementById("parentResult");

let html = `
        <button type="button">First</button>
        <button type="button">Second</button>
        <button type="button">Third</button>  
        `;


parentResult.addEventListener(
    "click",
    function (e) {
        console.log("Parent div clicked");
        console.log(e.target);
        console.log(e.currentTarget);
    }
);

setTimeout(() => {
    parentResult.innerHTML = html;
}, 2000);