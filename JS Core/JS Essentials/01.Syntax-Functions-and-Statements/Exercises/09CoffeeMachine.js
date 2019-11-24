function cafe(arr) {

    let sum=0;

    for (let i = 0; i < arr.length; i++) {
        let input = arr[i];
        let order = input.split(', ');

        let coins = order[0];
        let drink = order[1];
        let drinkPrice;

        if(drink==='coffee'){

            if(order[2]==='caffeine'){
                drinkPrice=0.8;
            }

            else{
                drinkPrice=0.9;
            }
        }

        else {
            drinkPrice=0.8;
        }

        if (order.includes('milk')){
            let milk=(drinkPrice*0.1).toFixed(1);
            drinkPrice+=+milk;
        }

        if(+order[order.length-1])
        {
            drinkPrice=+drinkPrice+0.1;
        }

        if(coins>=drinkPrice){
            console.log(`You ordered ${drink}. Price: $${drinkPrice.toFixed(2)} Change: $${(coins-drinkPrice).toFixed(2)}`)
            sum +=drinkPrice;
        }

        else {
            console.log(`Not enough money for ${drink}. Need $${(-coins+drinkPrice).toFixed(2)} more.`)
        }
        //console.log(drinkPrice);
    }
    console.log(`Income Report: $${sum.toFixed(2)}`)
}

//cafe(['1.00, coffee, caffeine, milk, 4', '0.40, tea, milk, 2', '1.00, coffee, decaf, 0']);