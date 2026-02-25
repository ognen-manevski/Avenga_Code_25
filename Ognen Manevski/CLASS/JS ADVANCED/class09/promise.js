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

getDocuments(url)
    .then(documents => {
        console.log("Documents fetched successfully.");
        console.log(documents);
        checkDocs(documents);
        return getImportantDocs(documents);
    })
    .then(importantDocs => {
        showDocs(importantDocs);
    })
    .catch(err => console.error(err.message))
    // .finally is executed regardless of error or success
    .finally(() => console.log("We finished handling the documents response."));
    