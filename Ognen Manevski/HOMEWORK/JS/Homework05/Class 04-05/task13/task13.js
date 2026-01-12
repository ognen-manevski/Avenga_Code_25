// ✅ JAVASCRIPT PRACTICE TASKS
// 1️⃣3️⃣ Remove Duplicates

// Goal: Remove duplicate values from an array.

// Function: function removeDuplicates()

// Input:

//     Array with duplicates

// Output: Array without duplicates

// Test Cases:

//     Input: [1, 2, 2, 3, 1] → Output: [1, 2, 3]
//     Input: [5, 5, 5] → Output: [5]

//plain version
function removeDuplicates(array) {

    let uniqueArray = [];

    for (let i = 0; i < array.length; i++) { //loop input arr

        let isDuplicate = false; //flag

        //loop unique arr for each input arr element
        for (let j = 0; j < uniqueArray.length; j++) {

            //if duplicate found, change flag to true and break inner loop
            if (array[i] === uniqueArray[j]) {
                isDuplicate = true;
                console.log(`Duplicate found: ${array[i]}`);
                break;
            }
        }

        if (!isDuplicate) { //if isDuplicate == true, dont add to uniqueArray
            uniqueArray.push(array[i]);
        }
    }

    console.log(`The uniqueArray is: ${uniqueArray}`);
    return uniqueArray;
}


//.includes
function removeDuplicatesV2(array) {

    let uniqueArray = [];

    for (let num of array) {
        if (!uniqueArray.includes(num)) {
            uniqueArray.push(num);
        } else {
            console.log(`Duplicate found: ${num}`);
        }
    }

    console.log(`The uniqueArray is: ${uniqueArray}`);
    return uniqueArray;
}


//test cases
let testArray1 = [1, 2, 2, 3, 1];
removeDuplicates(testArray1); // [1, 2, 3]
removeDuplicatesV2(testArray1); // [1, 2, 3]

let testArray2 = [5, 5, 5];
removeDuplicates(testArray2); // [5]
removeDuplicatesV2(testArray2); // [5]