import userService from "./modules/userService.js";

let users = await userService.getAll();
console.log(users);

let firstUser = await userService.getById(1);   
console.log(firstUser);
