function solve(input) {
    let totalMoney=0;

    for (let i = 0; i < input.length; i++) {
        let order = input[i].split(`, `);
        let cost = 0;
        let coins = +order[0];
        let typeD = order[1];

        if (typeD === `coffee` && order[2] === 'caffeine') {
            cost = 0.80;
        } else if (typeD === `coffee` && order[2] === 'decaf') {
            cost = 0.90;
        } else {
            cost = 0.80;
        }

        if (order.includes(`milk`)) {
            cost +=+(cost*0.1).toFixed(1);
        }

        let sugar = Number(order[order.length-1]);
        if (sugar>0){
            cost +=+0.1;
        }

        if(coins>=cost){
            console.log(`You ordered ${typeD}. Price: ${cost.toFixed(2)}$ Change: ${(coins-cost).toFixed(2)}$`);
            totalMoney+=cost;
        }
        else {
            console.log(`Not enough money for ${typeD}. Need ${(cost-coins).toFixed(2)}$ more.`)
        }
    }

    console.log(`Income Report: ${totalMoney.toFixed(2)}$`);


}

solve(['1.00, coffee, caffeine, milk, 4', '0.40, tea, milk, 2',
    '1.00, coffee, decaf, 0']
);