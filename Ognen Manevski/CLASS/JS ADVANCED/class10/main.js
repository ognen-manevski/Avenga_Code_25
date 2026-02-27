function Product(name, category, quantity, price) {
    this.name = name;
    this.category = category;
    this.quantity = quantity;
    this.price = price;
    this.inStock = quantity > 0; //true false
    this.updateStock = function (amount) {
        if (amount > this.quantity) {
            // throw error 
            console.log("Not enough stock");
            return;
        }
        this.quantity = this.quantity - amount;
        this.inStock = this.quantity > 0;
    }
}
// let product = new Product("Laptop", "Electronics", 10, 1200);
// console.log(product.inStock);
// product.updateStock(5);
// console.log(product.inStock);

//this keyword

// console.log(this);

// window.whereIsThis = function() {
//     console.log(this);
// }

// window.whereIsThis2 = function() {
//     console.log(this);
// }

// window.whereIsThis();

// whereIsThis2();

const person = {
    name: "John",
    greet: () => {
        console.log(this);
    },
    greet1: function () {
        console.log(this);
    },
    greet2: function() {
        const arrow = () => {
            console.log(this);
        }
        arrow();
    },
}
// person.greet(); //window
// person.greet1(); //person
// person.greet2(); //person

function Car () {
    console.log(this);
    this.name = "Toyouta";
    this.drive = function() {
        console.log(this);
    }
    this.start = () => {
        console.log(this);
    }    
}

Car(); //window
let car = new Car(); //Car object
car.drive(); //Car object
car.start(); //Car object because arrow function does not have its own this,
// it takes it from the surrounding context which is the Car function.
