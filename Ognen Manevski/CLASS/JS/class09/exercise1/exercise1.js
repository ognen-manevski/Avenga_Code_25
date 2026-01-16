function greet() {
    alert("Hello!");
}

let btn = document.getElementById("btn");
btn.addEventListener("click", greet);



window.addEventListener("mousemove", function (e) {
    // console.clear();
    console.log("Mouse moved: ", e.clientX, e.clientY);
});