// Exercise 1
// There is a JSON file with students. Make a call to the file and get the following data from it:

// All students with an average grade higher than 3
// All female student names with an average grade of 5
// All male student full names who live in Skopje and are over 18 years old
// The average grades of all female students over the age of 24
// All male students with a name starting with B and average grade over 2
// Use higher order functions to find the answers Link:
// https://raw.githubusercontent.com/sedc-codecademy/skwd9-04-ajs/main/Samples/students_v2.json


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
    averageGradeHigherThan3(data);
    femaleStudent_Names_WithGrade_5(data);
    maleStudent_FullNames_inSkopje_and_over18(data);
    averageGrades_Female_over24(data);
    maleStudents_NameStarts_B_AND_AverageGrade_abocve_2(data);
}

/////////////////////////////////////////
// #region requirements
/////////////////////////////////////////

// All students with an average grade higher than 3
function averageGradeHigherThan3(data) {
    let arr = data.filter(student => student.averageGrade > 3);
    console.log("All students with an average grade higher than 3:", arr);
}

// All female student names with an average grade of 5
function femaleStudent_Names_WithGrade_5(data) {
    let arr = data.filter(student =>
        student.gender === "Female" &&
        student.averageGrade === 5
    );
    arr = arr.map(student => student.firstName);
    console.log("All female student names with an average grade of 5:", arr);
}

// All male student full names who live in Skopje and are over 18 years old
function maleStudent_FullNames_inSkopje_and_over18(data) {
    let arr = data.filter(student =>
        student.gender === "Male" &&
        student.city === "Skopje" &&
        student.age > 18
    );
    arr = arr.map(student => `${student.firstName} ${student.lastName}`);
    console.log("All male student full names who live in Skopje and are over 18 years old:", arr);
}

// The average grades of all female students over the age of 24
function averageGrades_Female_over24(data) {
    let arr = data.filter(student =>
        student.gender === "Female" &&
        student.age > 24
    );
    arr = arr.map(student => student.averageGrade);
    console.log("The average grades of all female students over the age of 24:", arr);
}

// All male students with a name starting with B and average grade over 2
function maleStudents_NameStarts_B_AND_AverageGrade_abocve_2(data) {
    let arr = data.filter(student =>
        student.gender === "Male" &&
        student.firstName.split("")[0] === "B" && 
        student.averageGrade > 2
    );
    console.log("All male students with a name starting with B and average grade over 2:", arr);
}

// #endregion
/////////////////////////////////////////