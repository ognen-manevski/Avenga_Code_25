// HOMEWORK PART 2
// Create a header generator
// ⁃ Create two inputs, one for text and one for color
// • Create a button that says: generate h1
// • When the button is clicked create a new header below the inputs and button
// • The new header should have the text and color from the inputs
//  ⁃ Additionally create an h3 element for messages
//  ⁃ If the person enters an invalid color or an empty text show an error message
//    in the h3 element You must use JQuery to complete the task

//html color names array
const htmlColorNames = [
    "aliceblue", "antiquewhite", "aqua", "aquamarine", "azure",
    "beige", "bisque", "black", "blanchedalmond", "blue",
    "blueviolet", "brown", "burlywood", "cadetblue", "chartreuse",
    "chocolate", "coral", "cornflowerblue", "cornsilk", "crimson",
    "cyan", "darkblue", "darkcyan", "darkgoldenrod", "darkgray",
    "darkgrey", "darkgreen", "darkkhaki", "darkmagenta", "darkolivegreen",
    "darkorange", "darkorchid", "darkred", "darksalmon", "darkseagreen",
    "darkslateblue", "darkslategray", "darkslategrey", "darkturquoise", "darkviolet",
    "deeppink", "deepskyblue", "dimgray", "dimgrey", "dodgerblue",
    "firebrick", "floralwhite", "forestgreen", "fuchsia", "gainsboro",
    "ghostwhite", "gold", "goldenrod", "gray", "grey",
    "green", "greenyellow", "honeydew", "hotpink", "indianred",
    "indigo", "ivory", "khaki", "lavender", "lavenderblush",
    "lawngreen", "lemonchiffon", "lightblue", "lightcoral", "lightcyan",
    "lightgoldenrodyellow", "lightgray", "lightgrey", "lightgreen", "lightpink",
    "lightsalmon", "lightseagreen", "lightskyblue", "lightslategray", "lightslategrey",
    "lightsteelblue", "lightyellow", "lime", "limegreen", "linen",
    "magenta", "maroon", "mediumaquamarine", "mediumblue", "mediumorchid",
    "mediumpurple", "mediumseagreen", "mediumslateblue", "mediumspringgreen", "mediumturquoise",
    "mediumvioletred", "midnightblue", "mintcream", "mistyrose", "moccasin",
    "navajowhite", "navy", "oldlace", "olive", "olivedrab",
    "orange", "orangered", "orchid", "palegoldenrod", "palegreen",
    "paleturquoise", "palevioletred", "papayawhip", "peachpuff",
    "peru", "pink", "plum", "powderblue", "purple",
    "rebeccapurple", "red", "rosybrown", "royalblue", "saddlebrown",
    "salmon", "sandybrown", "seagreen", "seashell", "sienna",
    "silver", "skyblue", "slateblue", "slategray", "slategrey",
    "snow", "springgreen", "steelblue", "tan", "teal",
    "thistle", "tomato", "turquoise", "violet", "wheat",
    "white", "whitesmoke", "yellow", "yellowgreen"
];

//hex characters array
const hexCharacters = ['0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F'];

//selecting elements
let textInput = $('#text');
let colorInput = $('#color');
let colorPicker = $('#color-picker');
let button = $('#btn');
let resultDiv = $('#result');

//sync color picker with color input
colorPicker.on('input', function () {
    colorInput.val(colorPicker.val());
});
//sync color input with color picker (hex only)
colorInput.on('input', function () {
    colorPicker.val(colorInput.val());
});

//validate inputs

//helper function to check hex color validity
function checkHexColor(color) {
    let hexPart = '';
    if (color.length === 7) {
        hexPart = color.slice(1);
    } else if (color.length === 4) {
        hexPart = color.slice(1).split('').map(char => char + char).join('');
    }
    for (let char of hexPart) {
        if (!hexCharacters.includes(char.toUpperCase())) {
            return false;
        }
    }
    return true;
}

//helper function for checking HTML color name format
function checkHtmlColorName(color) {
    return htmlColorNames.includes(color.toLowerCase());
}

//color validation
function colorValidation(color) {
    if (color.trim() === '') {
        return false;
    }
    //check for color name format
    if (checkHtmlColorName(color)) {
        return true;
    }
    //check for hex color format
    if (checkHexColor(color)) {
        return true;
    }
    return false;
}

//text validation
function textValidation(text) {
    return text.trim() !== '';
}

//button click event function
function buttonClicked() {
    //reset result div
    resultDiv.html(''); //jQuery method to set HTML content
    //heading html content string
    let headingHTML = '';
    //getting values from inputs
    //.val() method is used to get the value of input fields in jQuery
    let textValue = textInput.val();
    let colorValue = colorInput.val();
    //validation and error messages
    if (!textValidation(textValue) && !colorValidation(colorValue)) {
        resultDiv.html('<h3 style="color:red;">Error: Please enter valid text and color.</h3>');
        return;
    } else if (!textValidation(textValue)) {
        resultDiv.html('<h3 style="color:red;">Error: Please enter valid text.</h3>');
        return;
    } else if (!colorValidation(colorValue)) {
        resultDiv.html('<h3 style="color:red;">Error: Please enter valid color.</h3>');
        return;
    }
    //capitalize first letter of text
    textValue = textValue.charAt(0).toUpperCase() + textValue.slice(1);
    //create heading html string
    headingHTML = `<h1 style="color:${colorValue}">${textValue}</h1>`;
    //append heading to result div
    resultDiv.html(headingHTML);
}

//event listener for button click
button.on('click', buttonClicked);