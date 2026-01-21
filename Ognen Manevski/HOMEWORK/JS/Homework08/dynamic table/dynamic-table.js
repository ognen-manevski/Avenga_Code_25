// Write a Javascript function that will dynamiclly create a table
// User should input the number of Colums and Rows
// In every table cell print which row and column it is (ex. Row-3 Column-1)


let btn = document.getElementById("btn");
let result_container = document.getElementById("result");
let rows_input = document.getElementById("rows");
let columns_input = document.getElementById("columns");


function createTable() {
    result_container.innerHTML = "";

    let rows = parseInt(rows_input.value);
    let columns = parseInt(columns_input.value);

    let table = buildTableHtml(rows, columns);
    result_container.innerHTML = table;
}

function buildTableHtml(rows, columns) {
    let htmlContent = "<table>";
    for (let i = 1; i <= rows; i++) {
        htmlContent += "<tr>";
        for (let j = 1; j <= columns; j++) {
            htmlContent += `
            <td>
                <span>Row:${i} </span>
                 <span>Col:${j}</span>
            </td>`;
        }
        htmlContent += "</tr>";
    }
    htmlContent += "</table>";
    return htmlContent;
}

btn.addEventListener("click", createTable);