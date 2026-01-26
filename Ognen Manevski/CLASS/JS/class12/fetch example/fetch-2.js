let peopleURL = "https://swapi.dev/api/people/";

let btn = document.getElementById("load-data");
let container = document.getElementById("container");
let tbody = document.querySelector("tbody");
let pagingBtns = document.getElementById("paging-btns");

btn.addEventListener("click", function () {
    fetchFunction(peopleURL);
});

function fetchFunction(url) {
    fetch(url)
        .then(function (response) {
            return response.json();
        })
        .then(function (data) {
            let swapiPeople = new SwapiPeopleResponse(
                data.count,
                data.next,
                data.previous,
                data.results
            );
            console.log(swapiPeople);
            generatePeopleTable(swapiPeople.results, tbody);
            generatePagingButtons(swapiPeople, pagingBtns);
            generatePagingButtonsEvents(pagingBtns);
        })
        .catch(function (error) {
            console.log(error);
        });
}

function generatePeopleTable(people, element) {
    let html = "";
    for (let person of people) {
        html += `
            <tr>
                <th scope="row">${person.name}</th>
                <td>${person.birth_year}</td>
                <td>${person.films.length}</td>
                <td>
                    <button type="button" value="${person.name}" class="btn btn-primary">
                        More Details
                    </button>
                </td>
            </tr >
            `;
    }
    element.innerHTML = "";
    element.innerHTML = html;
}

function generatePagingButtons(swapiResponse, pagingBtns) {
    let buttons = `
         <button class="btn btn-secondary btn-grey" id="prev-btn" type="button"
         ${swapiResponse.hasPreviousPage() ? "" : "disabled"}
         value="${swapiResponse.previousPage}">
             Previous
         </button>
        <button class="btn btn-secondary btn-grey" id="next-btn" type="button"
        ${swapiResponse.hasNextPage() ? "" : "disabled"}
        value="${swapiResponse.nextPage}">
             Next
         </button>
     `;
    pagingBtns.innerHTML = "";
    pagingBtns.innerHTML = buttons;
}

function generatePagingButtonsEvents(element) {
    let btns = element.getElementsByTagName("button");
    for (let btn of btns) {
        btn.addEventListener("click", function (e) {
            let pageUrl = e.target.value;
            fetchFunction(pageUrl);
        });
    }
}

container.addEventListener("click", function (e) {
    e.preventDefault();
    if(e.target.nodeName === "BUTTON"){
        let name = e.target.value;
        fetchPeopleByName(name);
    };
});

function fetchPeopleByName(name) {
    fetch(peopleURL)
        .then(function (response) {
            return response.json();
        })
        .then(function (data) {
            let swapiPeople = new SwapiPeopleResponse(
                data.count,
                data.next,
                data.previous,
                data.results
            );
            let person = swapiPeople.getPeopleByName(name);
            console.log(person);
        })
        .catch(function (error) {
            console.log(error);
        });
}