// calculate the price of 30 phones where the price of one phone is $119.95 and the tax rate is 5%

const phonePrice = 119.95;
const taxRate = 0.05;
const numberOfPhones = 30;

const totalPriceBeforeTax = phonePrice * numberOfPhones;
const taxAmount = totalPriceBeforeTax * taxRate;
const totalPriceAfterTax = totalPriceBeforeTax + taxAmount;
console.log("Total price after tax: $" + totalPriceAfterTax.toFixed(2));