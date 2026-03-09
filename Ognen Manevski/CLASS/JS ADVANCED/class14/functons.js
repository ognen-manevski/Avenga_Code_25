let sayHello = (personName) => {
    console.log(`Hello ${personName}! Have a nice day!`);
}

let sayGoodbye = (personName) => {
    console.log(`Goodbye ${personName}! See you later!`);
}

let printInConsole = (text) => {
    if(!text){
        throw new Error('Text is required!');
    }
    console.log(text);
}

module.exports = {
    sayHello,
    sayGoodbye,
    printInConsole
}