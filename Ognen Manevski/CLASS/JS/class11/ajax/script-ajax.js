let baseUrl = "https://jsonplaceholder.typicode.com/";

let postsUrl = "https://jsonplaceholder.typicode.com/posts";

$("#btn").on("click", function () {
    $.ajax({
        url: postsUrl,
        method: "GET",
        success: function (serverOutput) {
            //or a separate function
            let html = "";
            for (let post of serverOutput) {
                html += `
                <li id="${post.id}">
                    <h3>${post.title}</h3>
                    <p>${post.body}</p>
                </li>`;
            }
            $("#posts").html(html);
        },
        error: function (err) {
            console.log("Error:", err);
        }
    });
});

$("#posts").on("click", function (e) {
    // console.log(e);
    $.ajax({
        url: postsUrl + "/" + e.target.parentElement.id,
        method: "GET",
        success: function (post) {
            alert(`Id: ${post.id}`);
        },
        error: function (err) {
            console.log("Error:", err);
        }
    });
}).css("cursor", "pointer");




