let obj = {
    name: "Ognen",
    lastName: "Manevski",
    age: 30,
    courses: [
        "JS",
        "HTML",
        "CSS"
    ],
    address: {
        street: "Some street",
        number: 123,
        city: "Skopje"
    },
    getAdress: function() {
        return this.address;
    }
}

let jsonObj = JSON.stringify(obj);
// console.log(jsonObj);

// Converting back to object
// cant use functions like getAdress
let toJson = JSON.parse(jsonObj);
// console.log(toJson);
// console.log(toJson.name);
