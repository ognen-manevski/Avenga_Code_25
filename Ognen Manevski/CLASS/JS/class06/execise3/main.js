let purchases = [5, 10, 15, 0, 25];

// function calculatePoints(amount) {
//     if (amount > 20) {
//         return 3;
//     } else if (amount >= 10 && amount <= 20) {
//         return 2;
//     } else if (amount < 10) {
//         return 1;
//     }
// }

// let totalPoints = 0;

// function calculateReward() {

//     for (let purchase of purchases) {

//         let points = calculatePoints(purchase);
//         totalPoints += points;
//     }

//     if (totalPoints >= 10) {
//         console.log('Reward earned: Free Cofee!');

//     } else {
//         let pointsNeeded = 10 - totalPoints;
//         console.log(`Points needed for reward: ${pointsNeeded} `);
//     }
// }

// calculateReward();

function calculatePoints(purchase) {
    if (purchase > 20) {
        return 3;
    } else if (purchase >= 10 && purchase <= 20) {
        return 2;
    } else if (purchase < 10) {
        return 1;
    }
}

let totalPoints = 0;

for (let purchase of purchases) {
    totalPoints += calculatePoints(purchase);
}

if (totalPoints >= 10) {
    console.log('Reward earned: Free Coffee!');
} else {
    // let pointsNeeded = 10 - totalPoints;
    console.log("Points needed for reward: 10");
    console.log(`You need ${10 - totalPoints} more points to earn a reward.`);
}