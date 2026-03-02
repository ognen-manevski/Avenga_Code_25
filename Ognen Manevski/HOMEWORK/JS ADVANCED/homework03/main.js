// #Exercises

// Exercise 1

// Create a Person constructor function that has:
//     firstName
//     lastName
//     age
//     getFullName - method

function Person(firstName, lastName, age) {
    this.firstName = firstName;
    this.lastName = lastName;
    this.age = age;
    this.getFullName = function () {
        return `${this.firstName} ${this.lastName}`;
    }
}

// Create a Student constructor function that inherits from Person and has:
//     academyName
//     studentId
//     study - method that writes in the console:
//             The student firstName is studying in the academyName

//od chas:
function Student(firstName, lastName, age, academyName, studentId) {
    Object.setPrototypeOf(this, new Person(firstName, lastName, age)); //pravi kopija od Person obj
    this.academyName = `${academyName} Academy`;
    this.studentId = studentId;
    this.study = function () {
        console.log(`The student ${this.getFullName()} is studying in the ${this.academyName}.`);
    }
}

//spored copilot:
function Student2(firstName, lastName, age, academyName, studentId) {
    Person.call(this, firstName, lastName, age); //?? calls the Person constructor with the current context
    this.academyName = `${academyName} Academy`;
    this.studentId = studentId;
    this.study = function () {
        console.log(`The student ${this.getFullName()} is studying in the ${this.academyName}.`);
    }
}
Student2.prototype = Object.create(Person.prototype); //inherit from Person prototype
Student2.prototype.constructor = Student2; //reset the constructor property to point to Student2 instead of Person

let john = new Student("John", "Doe", 20, "Code", 123);
console.log(john);
let jane = new Student("Jane", "Smith", 22, "Design", 456);
console.log(jane);

let john2 = new Student2("John", "Doe", 20, "Code", 123);
console.log(john2);
let jane2 = new Student2("Jane", "Smith", 22, "Design", 456);
console.log(jane2);


// Exercise 2

// Create a method on the Person prototype that accepts a Student of any academy and returns the academy that that student is in.
Person.prototype.checkAcademy = function (student) {
    return student.academyName;
}
Person.prototype.checkAcademy2 = function () { //vaka mi pravi povejke smisla, polesno e za povikuvanje bez argument
    return this.academyName;
}

// Create DesignStudent, CodeStudent and NetworkStudent constructor functions that inherit from Student.
// DesignStudent
//     isStudentOfTheMonth - boolean
//     attendAdobeExam - method that writes in console: The student firstName is doing an adobe exam!
function DesignStudent(firstName, lastName, age, studentId, isStudentOfTheMonth) {
    Object.setPrototypeOf(this, new Student(firstName, lastName, age, "Design", studentId)); //design hardcoded
    this.isStudentOfTheMonth = isStudentOfTheMonth;
    this.attendAdobeExam = function () {
        console.log(`The student ${this.firstName} is doing an Adobe exam!`);
    }
}

// CodeStudent
//     hasIndividualProject - boolean
//     hasGroupProject - boolean
//     doProject(type) - method that accepts string. If the string is individual or group it should write that the person is working on the project of that type and set the value to true on the property of the project
function CodeStudent(firstName, lastName, age, studentId) {
    Object.setPrototypeOf(this, new Student(firstName, lastName, age, "Code", studentId)); //code hardcoded
    this.hasIndividualProject = false;
    this.hasGroupProject = false;
    this.doProject = function (type) {
        if (type === "individual") {
            this.hasIndividualProject = true;
            console.log(`The student ${this.firstName} is working on an ${type} project.`);
        } else if (type === "group") {
            this.hasGroupProject = true;
            console.log(`The student ${this.firstName} is working on a ${type} project.`);
        } else {
            console.log(`Invalid project type. Please specify "individual" or "group".`);
        }
    }
}

// NetworkStudent
//     academyPart - number
//     attendCiscoExam - method that writes in console: the student firstNAme is doing a cisco exam!
function NetworkStudent(firstName, lastName, age, studentId, academyPart) {
    Object.setPrototypeOf(this, new Student(firstName, lastName, age, "Network", studentId)); //network hardcoded
    this.academyPart = academyPart;
    this.attendCiscoExam = function () {
        console.log(`The student ${this.firstName} is doing a Cisco exam!`);
    }
}
// Note: For all students, the academyName property should be auto generated based on which Student we are creating ( design, code or network )

// Create one of each students Check all students with the Student method for checking students academy

let designStudent = new DesignStudent("Alice", "Johnson", 21, 789, true);
// console.log(designStudent);
// designStudent.attendAdobeExam();
console.log(designStudent.checkAcademy(designStudent));
console.log(designStudent.checkAcademy2());

let codeStudent = new CodeStudent("Bob", "Smith", 23, 1011);
// console.log(codeStudent);
// codeStudent.doProject("group");
console.log(codeStudent.checkAcademy(codeStudent));
console.log(codeStudent.checkAcademy2());

let networkStudent = new NetworkStudent("Charlie", "Brown", 24, 121314, 1);
// console.log(networkStudent);
// networkStudent.attendCiscoExam();
console.log(networkStudent.checkAcademy(networkStudent));
console.log(networkStudent.checkAcademy2());


// =================================================================

// You are encouraged to use AI tools (like ChatGPT or GitHub Copilot) to help you write the classes, functions,
// and methods. Use AI as a learning assistant, not to copy everything blindly.
// You can ask for hints, examples, or code templates and then implement the logic yourself.
// Make sure to test your code in the browser console or VS Code to understand how objects interact dynamically.