let inputs = document.getElementsByTagName('input');

document
    .querySelector('button')
    .addEventListener('click', function () {
        //object init
        let loginForm = {};
        //object population
        for (let input of inputs) {
            //key value pairs
            loginForm[input.name] = input.value;
        }
    });


// less efficient way for ^    
// document
//     .querySelector('button')
//     .addEventListener('click', function () {
//         let username = inputs[0].value;
//         let password = inputs[1].value;
//     });