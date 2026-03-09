const txtService = require('./textService.js');

txtService.writeInFile("I want this text to be in the file")
.then(() => txtService.appendInFile("New line added"))
.then(() => txtService.readFromFile())
.catch((err) => {
    console.log("Error writing in file");
});

//calling write method several timews will overwrite the file content each time
// txtService.writeInFile("New line added");
// txtService.writeInFile("And another line added");


