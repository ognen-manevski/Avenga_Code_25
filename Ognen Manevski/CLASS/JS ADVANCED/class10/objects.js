let obj = {
    name: 'John',
    lastName: 'Smith',
}

let person = Object.create(obj);
console.log(person.name, person.lastName);

const target = { a: 1, b: 2 };
const source = { b: 4, c: 5 };

let obj1 = { ...target, ...source };
console.log(obj1);

let obj2 = Object.assign(target, source);
console.log(obj2);
// console.log(target); //target is mutated

console.log(Object.entries(obj)); //[key-value]
console.log(Object.keys(obj)); //just keys
console.log(Object.values(obj)); //just values

for (let [key, value] of Object.entries(obj)) {
    console.log(key, value);
}

let obj3 = { ...obj };
console.log(obj3);

Object.freeze(obj3);
obj3.name = 'Jane';
obj3.newProp = 'new';
console.log(obj3);

let config = {
    apiUrl: 'https://api.example.com',
    apiKey: '1234567890',
    user: {},
}
// Object.freeze(config);
if (!Object.isFrozen(config)) {
    Object.freeze(config);
}

let config1 = {
    ...config,
}

Object.seal(config1);
config1.apiKey = "new123";
config1.user = { name: 'John' };
config1.newProp = 'new';
delete config1.apiUrl;
console.log(config1);


