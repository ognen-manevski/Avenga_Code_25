let paragraph = document.getElementById("paragraph");

document
    .getElementById("btn")
    .addEventListener("click", function () {
        paragraph.style.color = "white";
        paragraph.style.backgroundColor = "red";
        paragraph.style.fontSize = "2rem";
        paragraph.style.fontWeight = "bold";
    });
    
