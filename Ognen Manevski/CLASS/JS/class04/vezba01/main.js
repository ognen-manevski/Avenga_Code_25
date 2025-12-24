let day = 1; // 1-7

switch (day) {
    case 1:
        console.log("Monday");
        break;

    case 2:
        console.log("Tuesday");
        break;
    case 3:
        console.log("Wednesday");
        break;

    case 4:
        console.log("Thursday");
        break;
    case 5:
        console.log("Friday");
        break;

    case 6:
        console.log("Saturday");
        break;

    case 7:
        console.log("Sunday");
        break;

    default:
        console.log("No day with this number exists.");
        break;
}


if (day === 1 || day === 3 || day === 5) {
    console.log("academy days");
} else if (day === 2 || day === 4) {
    console.log("learning days");
} else if (day === 6 || day === 7) {
    console.log("weekend");
} else {
    console.log("no such day");
}

switch (day) {
    case 1:
    case 3:
    case 5:
        console.log("academy days");
        break;
    case 2:
    case 4:
        console.log("learning days");
        break;
    case 6:
    case 7:
        console.log("weekend");
        break;
    default:
        console.log("no such day");
        break;
}

let name1 = "Ognen";

switch (name1) {
    case "Ognen":
        console.log("Welcome Ognen!");
        break;

    case "John":
        console.log("Welcome John!");
        break;

    default:
        console.log("Welcome guest!");
        break;
}


