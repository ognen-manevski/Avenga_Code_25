export class MathOperation {
    static PI = 3.14;
    static sum(a, b) {
        return a + b;
    }
    static subtract(a, b) {
        return a - b;
    }
    static multiply(a, b) {
        return a * b;
    }
    static divide(a, b) {
        if (b === 0) {
            throw new Error('Divide by zero exception: Cannot divide by zero!');
        }
        return a / b;
    }
}

//as an alternative we can export the class as a named export
// export default {
//     sum: sum,
//     subtract: subtract,
//     multiply: multiply,
//     divide: divide
// }