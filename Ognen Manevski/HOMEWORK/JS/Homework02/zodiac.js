// write js code that will get an input from the user and calculate which chinese zodiac a given year is in.

// formula for chinese zodiac calculation: (year - 4) % 12

// possible values:
// 0 - Rat
// 1 - Ox
// 2 - Tiger
// 3 - Rabbit
// 4 - Dragon
// 5 - Snake
// 6 - Horse
// 7 - Goat
// 8 - Monkey
// 9 - Rooster
// 10 - Dog
// 11 - Pig

//the zodiac array in indexed order
let zodiacSigns = [
    "Rat",
    "Ox",
    "Tiger",
    "Rabbit",
    "Dragon",
    "Snake",
    "Horse",
    "Goat",
    "Monkey",
    "Rooster",
    "Dog",
    "Pig"
];

//getting user input
let input = prompt("Enter a year to find out its Chinese Zodiac sign:");

let year = parseInt(input);

if (!Number.isNaN(year)) {

    let zodiacIndex = (year - 4) % 12; //calculating the zodiac index
    let zodiacSign = zodiacSigns[zodiacIndex]; //getting the zodiac sign from the array
    console.log(zodiacSign);

} else {
    console.log("Please enter a valid year.");
}