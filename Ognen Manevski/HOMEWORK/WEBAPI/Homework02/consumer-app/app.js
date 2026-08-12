const url = 'https://localhost:1234/api/Users';


const newUserObject = {
  "firstName": "Boban",
  "lastName": "Bobanovski"
}

fetch(url, {
    method: 'POST',
    headers: {
        'Content-Type': 'application/json'
    },
    body: JSON.stringify(newUserObject),
})
    .then(response => response.json())
    .then(data => console.log('Success:', data))
    .catch(error => console.error('Error:', error));


setTimeout(function () {
    fetch(url)
        .then(response => response.json())
        .then(data => console.log('Notes:', data))
}, 500)