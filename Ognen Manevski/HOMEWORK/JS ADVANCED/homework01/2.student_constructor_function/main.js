//Student constructor function
function Student(firstName, lastName, birthYear, academy, grades) {
    this.firstName = firstName;
    this.lastName = lastName;
    this.birthYear = birthYear;
    this.academy = academy;
    this.grades = grades;
    //methods
    this.getAge = function () {
        let currentYear = new Date().getFullYear();
        return currentYear - this.birthYear;
    }
    this.getInfo = function () {
        return `This is student ${this.firstName} ${this.lastName} from the academy ${this.academy}!`;
    }
    this.gradesAverage = function () {
        let sum = 0;
        for (let grade of this.grades) {
            sum += grade;
        }
        return sum / this.grades.length;
    }
}

//Create an array with 3 students
function createStudentsArray() {
    let studentsArr = [];
    let student1 = new Student('John', 'Doe', 1995, 'SEDC', [8, 9, 10]);
    let student2 = new Student('Johny', 'Doee', 1996, 'Qinshift', [11, 12, 13]);
    let student3 = new Student('Johnson', 'Doeeee', 1997, 'Avenga', [14, 15, 16]);
    studentsArr.push(student1, student2, student3);
    return studentsArr;
}
console.log(createStudentsArray());
