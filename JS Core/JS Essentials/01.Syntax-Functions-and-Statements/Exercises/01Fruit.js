function priceFruit(fruit,weight, price) {
    weight/=1000;
    let money =(weight*price).toFixed(2);
    let result = `I need $${money} to buy ${weight.toFixed(2)} kilograms ${fruit}.`
    console.log(result);
}

priceFruit('orange', 2500, 1.80);