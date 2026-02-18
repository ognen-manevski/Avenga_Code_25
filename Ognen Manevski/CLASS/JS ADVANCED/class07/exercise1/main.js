// Exercise 1
// There is a JSON file with students. Make a call to the file and get the following data from it:

//  1.1 All students with an average grade higher than 3
//  1.2 All female student names with an average grade of 5
//  1.3 All male student full names who live in Skopje and are over 18 years old
//  1.4 The average grades of all female students over the age of 24
//  1.5 All male students with a name starting with B and average grade over 2

// New requirements HOMEWORK

//     All students who are older than 30 (return full name + age)
//     All students from a city that starts with B (return full name + city)
//     All student emails (just an array of emails)
//     All students with average grade exactly 3 (return full name)
//     Count how many students are Female and how many are Male

// Use higher order functions to find the answers
// Link: https://raw.githubusercontent.com/sedc-codecademy/skwd9-04-ajs/main/Samples/students_v2.json



//api call
const url = "https://raw.githubusercontent.com/sedc-codecademy/skwd9-04-ajs/main/Samples/students_v2.json";

function getData() {
    fetch(url)
        .then(response => response.json())
        .then(data => {
            console.log(data);
            dataProcessing(data);
        })
        .catch(error => console.error(error));
}
getData();

//data processing functions 
function dataProcessing(data) {
    //part 1
    task_1_1(data);
    task_1_2(data);
    task_1_3(data);
    task_1_4(data);
    task_1_5(data);
    //part 2
    task_2_1(data);
    task_2_2(data);
    task_2_3(data);
    task_2_4(data);
    task_2_5(data);
}

/////////////////////////////////////////
// #region solutions
/////////////////////////////////////////

// 1-1 All students with an average grade higher than 3
function task_1_1(data) {
    let obj = data.filter(student => student.averageGrade > 3);
    console.log("All students with an average grade higher than 3:", obj);
    return obj;
}

// 1-2 All female student names with an average grade of 5
function task_1_2(data) {
    let arr = data.filter(student =>
        student.gender === "Female" &&
        student.averageGrade === 5
    );
    arr = arr.map(student => student.firstName);
    console.log("All female student names with an average grade of 5:", arr);
    return arr;
}

// 1-3 All male student full names who live in Skopje and are over 18 years old
function task_1_3(data) {
    let arr = data.filter(student =>
        student.gender === "Male" &&
        student.city === "Skopje" &&
        student.age > 18
    );
    arr = arr.map(student => `${student.firstName} ${student.lastName}`);
    console.log("All male student full names who live in Skopje and are over 18 years old:", arr);
    return arr;
}

// 1-4 The average grades of all female students over the age of 24
function task_1_4(data) {
    let arr = data.filter(student =>
        student.gender === "Female" &&
        student.age > 24
    );
    arr = arr.map(student => student.averageGrade);
    console.log("The average grades of all female students over the age of 24:", arr);
    return arr;
}

// 1-5 All male students with a name starting with B and average grade over 2
function task_1_5(data) {
    let arr = data.filter(student =>
        student.gender === "Male" &&
        // student.firstName.split("")[0] === "B" && 
        student.firstName.startsWith("B") &&
        student.averageGrade > 2
    );
    console.log("All male students with a name starting with B and average grade over 2:", arr);
    return arr;
}

// New requirements HOMEWORK

// 2-1 All students who are older than 30 (return full name + age)
function task_2_1(data) {
    let arr = data.filter(student => student.age > 30);
    arr = arr.map(student => `${student.firstName} ${student.lastName} - Age: ${student.age}`);
    console.log("All students who are older than 30:", arr);
    return arr;
}

// 2-2 All students from a city that starts with B (return full name + city)
function task_2_2(data) {
    let arr = data.filter(student => student.city.startsWith("B"));
    arr = arr.map(student => `${student.firstName} ${student.lastName} - City: ${student.city}`);
    console.log("All students from a city that starts with B:", arr);
    return arr;
}

// 2-3 All student emails (just an array of emails)
function task_2_3(data) {
    let arr = data.map(student => student.email);
    console.log("All student emails:", arr);
    return arr;
}

// 2-4 All students with average grade exactly 3 (return full name)
function task_2_4(data) {
    let arr = data.filter(student => student.averageGrade === 3);
    arr = arr.map(student => `${student.firstName} ${student.lastName}`);
    console.log("All students with average grade exactly 3:", arr);
    return arr;
}

// 2-5 Count how many students are Female and how many are Male
function task_2_5(data) {
    let malesNo = data.filter(student => student.gender === "Male").length;
    let femalesNo = data.filter(student => student.gender === "Female").length;
    console.log("Number of male students:", malesNo);
    console.log("Number of female students:", femalesNo);
    return {malesNo, femalesNo};
}
//using reduce
function task_2_5_1(data) {
    //acc -> accumulator
    //student -> current
    //{ 0, 0 } -> initial object
    let obj = data.reduce((acc, student) => {
        if (student.gender === "Male") {
            acc.malesNo++;
        } else {
            acc.femalesNo++;
        }
        return acc;
    }, { malesNo: 0, femalesNo: 0 });
    console.log("Number of male students:", obj.malesNo);
    console.log("Number of female students:", obj.femalesNo);
    return obj;
}

// #endregion
/////////////////////////////////////////