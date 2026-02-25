const url = "https://raw.githubusercontent.com/sedc-codecademy/skwd9-04-ajs/main/Samples/documents.json";

function getDocuments(url) {
    return new Promise((resolve, reject) => {
        fetch(url)
            .then(resp => resp.json())
            .then(data => resolve(data))
            .catch(error => reject(error));
    })
}

function getImportantDocs(documents) {
    let importantDoc = documents.filter(doc => doc.important);
    return new Promise((resolve, reject) => {
        if (importantDoc.length === 0) {
            reject("No important documents found.");
        }
        resolve(importantDoc);
    });
}

function checkDocs(documents) {
    if (!documents || typeof documents !== "object") {
        throw new Error("Problem with documents.");
    }
    if (documents.length === 0) {
        throw new Error("There are no documents.")
    }
}

function showDocs(docs) {
    console.log("Important documents:");
    docs.forEach(doc => {
        console.log(`Document: ${doc.name}.${doc.type} - ${doc.size} MB`);
    })
}

async function showImportantOnlyDocs() {
    let startTime = new Date().getTime();
    try {
        let docs = await getDocuments(url);
        checkDocs(docs);
        let importantDocs = await getImportantDocs(docs);
        showDocs(importantDocs);
    } catch (err) {
        console.log("Error occured: " + err);
    } finally {
        let timeDelta = (new Date().getTime() - startTime)/1000;
        console.log("Total time taken: " + timeDelta + " sec");
    }
}

// showImportantOnlyDocs();