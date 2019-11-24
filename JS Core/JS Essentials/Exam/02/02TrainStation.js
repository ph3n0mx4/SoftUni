function f(num, arr) {
    let newArr=arr.slice(0);
    let wagon = [];
    let otherP=0;

    for (let i = 0; i < arr.length; i++) {
        let currentP=newArr[i];

        if(currentP<=num){
            wagon.push(currentP);
            newArr[i]=0;
        }
        else if(i===arr.length-1 && num<newArr[i]){
            wagon.push(num);
            otherP+=newArr[i]-num;
        }
        else {
            wagon.push(num);
            let a = currentP-num
            let nextP=newArr[i+1]+a;
            newArr[i+1]=nextP;
        }
    }
    let result =`All passengers aboard`;
    if(otherP!==0){
        result=`Could not fit ${otherP} passengers`;
    }
    console.log(wagon);
    console.log(result);
    //console.log(wagon.join(`,`));
    //console.log(otherP);
}

f(10, [9, 39, 1, 0, 0])
f(6, [5, 15, 2])