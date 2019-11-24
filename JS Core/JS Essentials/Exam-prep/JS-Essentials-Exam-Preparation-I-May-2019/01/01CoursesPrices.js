function f(fund, adv, app, forms) {
    let price = 0;
    if (adv && fund && app) {
        price += 170*0.94;
    }
    else if (fund){
        price += 170;
    }
    if(adv && fund && app){
        price += 180*0.9*0.94;
    }
    else if (adv && fund) {
        price += 180*0.9;
    }
    else if (adv){
        price += 180;
    }

    if (adv && fund && app) {
        price += 190*0.94;
    }
    else if(app){
        price += 190;
    }

    if(forms===`online`){
        price-=price*0.06;
    }
    console.log(price.toFixed(0));
}

f(true, false, false, "onsite");
f(true, false, false, "online");
f(true, true, false, "onsite");