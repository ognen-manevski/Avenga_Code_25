//app for organising groceries

let groceries = ['Bread', 'Milk', 'Butter', 'Salad'];

function addGrocerie(item) {

    let toNumber = parseInt(item);

    if (Number.isNaN(toNumber) || item === null) {

        groceries.push(item);
        console.log(`You have added ${item} to the list.`);

    } else {
        console.log(`The item ${item} was not added to the list. Sorry.`);
    }
}

function removeitemFromGrocerie(item) {

    if (item === null || item === '') {
        return;
    }

    for (let i = 0; i < groceries.length; i++) {
        let element = groceries[i];
        if (element.toLowerCase() === item.toLowerCase()) {
            groceries[i] = null;
            console.log(`You have removed ${item} from the list.`);
            break;
        }
    }

    let tempGroceries = [];
    for (let grocerie of groceries) {
        if (!grocerie) {
            continue;
        }
        tempGroceries.push(grocerie);
    }
    groceries = tempGroceries;
}

let list = document.getElementById('groceryList');
list.innerHTML = '';

function showGrocerieList() {

    let i = 0;
    let listNum = 1;

    while (i < groceries.length) {
        let str = `${listNum}. ${groceries[i]}`;
        let listItem = document.createElement('li');
        listItem.textContent = str;
        list.appendChild(listItem);
        i++;
        listNum++;
    }
}


function searchItemInList(item) {

    if (item !== null || item !== '') {

        for (let listitem of groceries) {
            if (listitem.toLowerCase() == item.toLowerCase()) {
                console.log(`The item ${item} is in the grocery list.`);
                return listitem;
            }
        }
    }
    console.log(`The item ${item} is not in the grocery list.`);
    return null;
}




document.addEventListener('DOMContentLoaded', showGrocerieList);

let itemInput = document.getElementById('itemInput');
let searchInput = document.getElementById('searchInput');

let addBtn = document.getElementById('addBtn');
addBtn.addEventListener('click', () => {
    addGrocerie(itemInput.value);
    showGrocerieList();
});

// let item = prompt('Enter grocerie item to add:');


let removeBtn = document.getElementById('delBtn');
removeBtn.addEventListener('click', () => {
    removeitemFromGrocerie(itemInput.value);
    showGrocerieList();
});

let searchBtn = document.getElementById('searchBtn');
searchBtn.addEventListener('click', () => {
    searchItemInList(searchInput.value);
});

// let deleteItem = prompt('Enter grocerie item to remove:');

// let searchItem = prompt('Enter grocerie item to search:');
// console.log(searchItemInList(searchItem));