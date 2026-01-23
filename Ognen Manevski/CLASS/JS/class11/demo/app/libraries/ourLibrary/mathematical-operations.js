/**
 * Calculates the sum of two numbers.
 * @param {number} a - The first number.
 * @param {number} b - The second number.
 * @returns {number} The sum of a and b.
 */
function sum(a, b) {
    return a + b;
}

/**
 * Calculates the difference between two numbers.
 * @param {number} a - The first number.
 * @param {number} b - The second number.
 * @returns {number} The difference of a minus b.
 */
function subtract(a, b) {
    return a - b;
}

/**
 * Calculates the product of two numbers.
 * @param {number} a - The first number.
 * @param {number} b - The second number.
 * @returns {number} The product of a and b.
 */
function multiply(a, b) {
    return a * b;
}

/**
 * Calculates the quotient of two numbers.
 * @param {number} a - The dividend (number to be divided).
 * @param {number} b - The divisor (number to divide by).
 * @returns {number} The quotient of a divided by b.
 * @throws {Error} Throws an error if b is zero.
 */
function divide(a, b) {
    if (b === 0) {
        throw new Error("Division by zero is not allowed.");
    }
    return a / b;
}   