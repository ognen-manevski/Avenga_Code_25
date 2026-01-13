//write a js program to display the reading staqtus of some book.
//the object shopuld have the next props:
// title, author, readingStatus and a method that will return info depending on the reading status eg. 
// already read 'The robots of dawn' by Isaac Asimov (if true)
//you still need to read 'Mockingjay' by Suzanne Collins (if false)
//Bonus enter the values from prompt or read them from html

function Book(title, author, readingStatus) {
    this.title = title;
    this.author = author;
    this.readingStatus = readingStatus;
    this.getInfo = function () {
        if (this.readingStatus) {
            return `Already read '${this.title}' by ${this.author}`;
        } else {
            return `You still need to read '${this.title}' by ${this.author}`;
        }
    }
}

let submitBtn = document.getElementById("btn");
submitBtn.addEventListener("click", readInfo);

function readInfo(e) {

    //prevent refresh
    e.preventDefault();

    //get info from html
    let title = document.getElementById("title").value;
    let author = document.getElementById("author").value;
    let readingStatus = document.querySelector('input[name="readingStatus"]:checked').value;

    if (readingStatus === "read") {
        readingStatus = true;
    } else {
        readingStatus = false;
    }

    //check if info
    if (title === "" || author === "") {
        alert("Please fill in all fields!");
        return;
    }

    //create new book object
    let book = new Book(title, author, readingStatus);

    //display results
    let resultList = document.getElementById("bookList");

    resultList.innerHTML += `<li>${book.getInfo()}</li>`;

    //clear from
    document.getElementById("form").reset();
}