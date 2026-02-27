let obj = {
    name: 'John',
    lastName: 'Doe',
    age: 30,
}

// Without destructuring
let name1 = obj.name;
let lastName1 = obj.lastName;
let age1 = obj.age;

// Destructuring
// let {name, lastName, age} = obj; //isto kako gore
// console.log(name);

let { name: ime, lastName: prezime, age: godini } = obj;
// console.log(ime);

let { name, lastName, age2 = 25 } = obj;
// console.log(age2);

function showPersonInfo(person) {
    console.log(person.name, person.lastName, person.age);
}
// showPersonInfo(obj);

function showPersonInfo2(name, lastName, age) {
    console.log(name, lastName, age);
}
// showPersonInfo2(obj.name, obj.lastName, obj.age);

function showPersonInfo3({ name, lastName, age }) {
    console.log(name, lastName, age);
}
// showPersonInfo3(obj);

let arr = [1, 2, 3, 4, 5];

let first = arr[0];
let second = arr[1];
let third = arr[2];
// console.log(first, second, third);

let [first2, second2, third2] = arr;
// console.log(first2, second2, third2);

let arr2 = [1, [1, 2, 3], [2]];

let [first3, [second3, third3, fourth3], [fifth3]] = arr2;
// console.log(first3, second3, third3, fourth3, fifth3);

let obj1 = {
    fnc: () => console.log('0'),
    fnc1: () => console.log('1'),
    fnc2: () => console.log('2'),
    fnc3: () => console.log('3'),
    fnc4: () => console.log('4'),
}

let { fnc4 } = obj1;
// fnc4();

//spread operator (...)

let obj2 = {
    name: 'Laptop',
    price: 1200,
    quantity: 20,
    inStock: true,
    category: 'Laptops',
}

let product = {
    // name: 'Laptop',
    // price: 1200,
    // quantity: 20,
    // inStock: true,
    // category: 'Laptops',
    ...obj2,
    name: "PC",
    price: 1500,
    components: ['ram', 'hdd', 'cpu', 'gpu'],
}

// console.log(obj2, product);

let arr3 = [1, 2];
let arr4 = [3, 4, 5];
let newArr = arr3.concat(arr4);
// console.log(newArr);
let newArr1 = [...arr3, ...arr4];
// console.log(newArr1);

let longArr = [1, 2, 3, 4, 5, 6, 7, 8, 9];
let [a, b, ... rest] = longArr;
// console.log(a, b, rest);

function sumOfThree(n1, n2, n3){
    return n1 + n2 + n3;
}
// console.log(sumOfThree(...longArr));



