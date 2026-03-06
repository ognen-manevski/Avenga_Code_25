function getAllUsers() {
    return JSON.parse(localStorage.getItem('users')) || [];
}

function getUserById(id) {
    let usersFromStorage = getAllUsers();
    return usersFromStorage.filter(u => u.id === id);
}

function addNewUser(user) {
    let usersFromStorage = getAllUsers();
    if (!user) throw new Error('User not valid');
    usersFromStorage.push(user);
    localStorage.setItem('users', JSON.stringify(usersFromStorage));
}

function deleteUser(id) {
    let usersFromStorage = getAllUsers();
    let userToDelete = usersFromStorage.filter(u => u.id === id)[0];
    usersFromStorage.splice(usersFromStorage.indexOf(userToDelete), 1);
    localStorage.setItem('users', JSON.stringify(usersFromStorage));
}

function editUser(user) {
    let usersFromStorage = getAllUsers();
    deleteUser(user.id);
    let userToEdit = usersFromStorage.filter(u => u.id === user.id)[0];
    userToEdit.name = user.name;
    userToEdit.username = user.username;
    userToEdit.email = user.email;
    userToEdit.city = user.city;
    userToEdit.street = user.street;
    userToEdit.companyName = user.companyName;
    usersFromStorage.push(userToEdit);
    localStorage.setItem('users', JSON.stringify(usersFromStorage));
}

export default {
    getAllUsers: getAllUsers,
    getUserById: getUserById,   
    addNewUser: addNewUser,
    deleteUser: deleteUser,
    editUser: editUser
}