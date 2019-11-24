function f(num) {
    let caf=0;
    let oneDay = (3*150*40+2*250*8+3*350*20)/100;
    let fivthDay = (3*500*30)/100;
    let nineDay = (4*250*8+2*500*30)/100;
    caf+=num*oneDay;
    if(num>=5){
        caf+=(Math.floor(num/5))*fivthDay;
    }

    if(num>=9){
        caf+=(Math.floor(num/9))*nineDay;
    }

    console.log(`${caf} milligrams of caffeine were consumed`)
}
f(8)