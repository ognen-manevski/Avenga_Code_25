function callInOrder() {
    setTimeout(() => {
        console.log("1. First thing, preparing for the second...");

        setTimeout(() => {
            console.log("2. Second thing");
        }, 100)

    }, 100)
}
// callInOrder();

// console.log("First");

// setTimeout(() => {
//     console.log("Second");
// }, 100)

// console.log("Third");

function complexCallInOrder() {
    setTimeout(() => {
        console.log("1. First thing, preparing for second...");
        setTimeout(() => {
            console.log("2. Second thing, preparing for third...");
            setTimeout(() => {
                console.log("3. Third thing, preparing for fourth...");
                setTimeout(() => {
                    console.log("4. Fourth thing, preparing for fifth...");
                    setTimeout(() => {
                        console.log("5. Fifth thing, preparing for sixth...");
                        setTimeout(() => {
                            console.log("6. Finally, sixth thing!");
                        }, 100)
                    }, 100)
                }, 100)
            }, 100)
        }, 100)
    }, 100)
}
// complexCallInOrder();

function workTimeResolvation(workTime) {
    return new Promise((resolve, reject) => {
        if (workTime <= 0) {
            reject("Its too short of a work time, please try again")
        }
        setTimeout(() => {
            resolve("This time is correct! Welcome!")
        }, workTime)
    })
}

// workTimeResolvation(0)
//     .then(data => {
//         console.log(data);
//     }
//     )
//     .catch(error => {
//         console.log(error);
//     });

// fetch("https://jsonplaceholder.typicode.com/todos/martin")
//     .then(response => {
//         console.log(response);
//         console.log(response).json();
//         return response.json();
//     })
//     .then(data => console.log(data))
//     .catch(error => {
//         console.log(error);
//     })

let myPromise = new Promise((resolve, reject) => {
    resolve("This is a resolved promise!");
    reject("This is a rejected promise!");
});
// console.log(myPromise);



