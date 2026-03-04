class Student {
    constructor(id, fname, lname, age, academyName) {
        this.id = id;
        this.fname = fname;
        this.lname = lname;
        this.age = age;
        this.academyName = academyName;
    }

    get age() {
        this._age > 18 ?
            console.log("This student is an adult.") :
            console.log("This student is a minor.");
    }
    set age(val) {
        if (val <= 0) {
            throw new Error("Age cannot be negative.");
        }
        this._age = val;
    }
}

let martin = new Student(1, 'Martin', 'Stojanovski', 32, 'Avenga Academy - Web Development');
// console.log(martin.age);

// let mario = new Student(2, 'Mario', 'Rossi', 0, 'Avenga Academy - Web Development'); // 0 y old! -> error
// console.log(mario.age);

console.log(martin instanceof Student);


