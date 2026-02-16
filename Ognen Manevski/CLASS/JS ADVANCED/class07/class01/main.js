//reduce
function reduceExample() {
    let student = {
        fullName: "Ognen Manevski",
        age: 30,
        academy: "Avenga Academy",
        grades: [6, 6, 7, 9, 10, 7, 8, 6, 8],
    }
    //without higher order functions
    function sumOfGrades_simple() {
        let allGradesAbove7 = [];
        let sum = 0;

        for (grade of student.grades) {
            if (grade > 7) {
                allGradesAbove7.push(grade);
            }
        }
        console.log(allGradesAbove7);

        for (grade of allGradesAbove7) {
            sum += grade;
        }

        sum = sum / allGradesAbove7.length;

        console.log(sum);
    };
    sumOfGrades_simple();
    //with higher order functions
    let averageGrade = student.grades
        .filter(grade => grade > 7)
        // sum each grade, starting with 0 as the initial value
        .reduce((sum, grade) => sum += grade, 0)
        / student.grades.filter(grade => grade > 7).length;
    console.log(averageGrade);
}

//pass by value vs pass by reference
//primitive types are passed by value, meaning that a copy of the value is created and passed to the function.
//non-primitive types (objects and arrays) are passed by reference,
//meaning that a reference to the original value is passed to the function, rather than a copy of the value.
function passByValue_vs_passByReference() {
    let numbers = [10, 20, 30, 40, 50];
    let numbersArr = numbers; //pass by reference
    numbersArr.push(60, 70, 80, 90, 100);
    console.log(numbers, numbersArr);
    //to avoid this, we can create a copy of the array using the spread operator
    let numbersArrCopy = [...numbers]; //pass by value
    numbersArrCopy.push(110, 120, 130, 140, 150);
    console.log(numbers, numbersArrCopy);
    //or
    function copyArr(arr) {
        let copied = [];
        arr.forEach(el => copied.push(el));
        return copied;
    }
    let numbersArrCopy2 = copyArr(numbers);
    numbersArrCopy2.push(160, 170, 180, 190, 200);
    console.log(numbers, numbersArrCopy2);
}


//array methods
function arrayMethods() {

    //every()
    let ages = [18, 20, 22, 32, 28, 29, 23, 33, 50, 62, 45, 66, 67, 69];
    //returns true or false
    let areAllAbove18 = ages.every(age => age >= 18);
    console.log(areAllAbove18);

    //some()
    let isSomeoneUnder18 = ages.some(age => age < 18);
    console.log(isSomeoneUnder18);

    //find()
    let cities = ["Skopje", "Prague", "Barcelona", "Ljubjana", "Paris"];
    let skopje = cities.find(city => city === "Skopje");
    console.log(skopje);
    //find returns the first element
    //filter returns an array of all elements that match the condition

    //findIndex()
    let barcelonaIndex = cities.findIndex(city => city === "Barcelona");
    console.log(barcelonaIndex);

    //includes()
    let isPragueInArray = cities.includes("Prague");
    console.log(isPragueInArray);

    //flat() and flatMap()
    let specialArray = [1, 2, 3, [4, 5, 6, [7, 8, 9]]];
    let flattened1 = specialArray.flat(1);
    let flattened2 = specialArray.flat(2);
    let flattenedInfinity = specialArray.flat(Infinity);
    //2 is the depth level to flatten the array.
    console.log(flattened1, flattened2, flattenedInfinity);

    let cityCharacters = cities.flatMap(city => city.split(""));
    console.log(cityCharacters);


    //join()
    let joinedCities = cityCharacters.join(",");
    console.log(joinedCities);

    //slice(), splice()
    //1 refers to the starting index, 4 refers to the ending index (not included)
    let sliced = cities.slice(1, 3);
    console.log(sliced);

    let spliced = [...cities].splice(2, 3);
    //splice modifies the original array
    //2 refers to the starting index, 3 refers to the number of elements to remove
    console.log(spliced, cities);

    //reverse()
    let reversed = cities.reverse();
    console.log(reversed);
}

// pure functions
//a pure function is a function that always returns
//the same output for the same input and has no side effects
//(does not modify any external state).
function pureFunctions() {


    //pure function
    function increaseByOne(numbers) {
        let result = [];
        for (let number of numbers) {
            result.push(number + 1);
        }
        return result;
    }


    //impure function
    let one = 1; //using a variable from the outer scope
    function increaseByOneImpure(numbers) {
        let result = [];
        for (let number of numbers) {
            result.push(number + one);
        }
        return numbers;
    }
    //impure 2 - mutatuting data from outide
    function increaseByOneImpure2(numbers) {
        for (let i = 0; i < numbers.length; i++) {
            numbers[i] += 1;
        }
        return numbers;
    }
    //impure 3
    function increaseByOneImpure3(numbers) {
        let result = [];
        for (let i = 0; i < numbers.length; i++) {
            result.push(numbers[i] + 1);
            document.getElementById("result").innerHTML += numbers[i] + " ";
            //modifying the DOM is a side effect
        }
        return result;
    }

    let numbers = [1, 2, 3, 4, 5];
    let increasedNumbers = increaseByOne(numbers);
    let increasedNumbersImpure2 = increaseByOneImpure2(numbers);
    let increasedNumbersImpure3 = increaseByOneImpure3(numbers);
    console.log(
        "numbers: " + numbers + "\n" +
        "increasedNumbers: " + increasedNumbers + "\n" +
        "increasedNumbersImpure2: " + increasedNumbersImpure2 + "\n" +
        "increasedNumbersImpure3: " + increasedNumbersImpure3
    );

}
// pureFunctions();