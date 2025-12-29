// HOMEWORK #1
// Create a function called tellStory()

// The function should accept an array of 3 strings as an argument: name, mood, activity ( All strings )

// The function should return one big string with a story made from the arguments

// Example: This is *name*. *name* is a nice person. Today they are *mood*. They are *activity* all day. The end.

// The value that is returned from the function should be printed in the console or in alert


let arr = [];

function getInputs() {
    let name = prompt("Enter a name:");
    let mood = prompt("Enter a mood:");
    let activity = prompt("Enter an activity:");
    arr.push(name, mood, activity);
    return arr;
}

getInputs();

function tellStory(arr) {
    let name = arr[0];
    let mood = arr[1];
    let activity = arr[2];

    let story = `This is ${name}. ${name} is a nice person. Today they are ${mood}. They are ${activity} all day. The end.`;
    console.log(story);
}

tellStory(arr);
