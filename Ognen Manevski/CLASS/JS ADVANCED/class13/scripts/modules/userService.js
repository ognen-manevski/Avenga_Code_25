const url = 'https://jsonplaceholder.typicode.com/users';


class User {
    constructor(id, name, username, email, city, street, companyName) {
        this.id = id;
        this.name = name;
        this.username = username;
        this.email = email;
        this.city = city;
        this.street = street;
        this.companyName = companyName;
    }
}

async function getAllUsers() {
    return await fetch(url)
        .then(res => res.json())
        .then(users => {
            return users.map(user => {
                return new User(
                    user.id,
                    user.name,
                    user.username,
                    user.email,
                    user.address.city,
                    user.address.street,
                    user.company.name
                );
            });
        })
        .catch(err => err)
        .finally(() => {console.log("Request All Users finished")});
}

async function getUserById(id) {
    return await fetch(`${url}/${id}`)
        .then(res => res.json())
        .then(user => {
            return new User(
                user.id,
                user.name,
                user.username,
                user.email,
                user.address.city,
                user.address.street,
                user.company.name
            );
        })
        .catch(err => err)
        .finally(() => console.log("Get User finished"));
}

export default {
    getAll: getAllUsers,
    getById: getUserById
}