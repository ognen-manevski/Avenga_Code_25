// calculate the price of 30 phones where the price of one phone is $119.95 and the tax rate is 5%

let phonePrice = 119.95;
let taxRate = 5;
let numberOfPhones = 30;

//calculating tax rate in percentage
let taxRatePercent = taxRate / 100;

//receipt with calculations

let totalPriceBeforeTax = phonePrice * numberOfPhones;
console.log(`Total price before tax: $${totalPriceBeforeTax.toFixed(2)}`); //2 decimal places + rounding up

let taxAmount = totalPriceBeforeTax * taxRatePercent;
console.log(`Total tax amount: $${taxAmount.toFixed(2)} (5%)`);

let totalPriceAfterTax = totalPriceBeforeTax + taxAmount;
console.log(`Total price after tax: $${totalPriceAfterTax.toFixed(2)}`);