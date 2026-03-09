const fs = require('fs').promises; //file system
const fileName = "testfile.txt";

let writeInFile = async (text) => {
    try {
        await fs.writeFile(fileName, text);
    } catch (param) {
        console.log("Error writing in file");
        return;
    }
}

let readFromFile = async () => {
    let fileContent = await fs.readFile(fileName, { encoding: "utf-8" });
    console.log(fileContent);
}


let appendInFile = async (text) => {
    let content = `\n${text}`;
    try {
        await fs.appendFile(fileName, content);
    } catch (param) {
        console.log("Error writing in file");
        return;
    }
}


module.exports = {
    writeInFile,
    readFromFile,
    appendInFile,
}