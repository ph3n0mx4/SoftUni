function GCD(a,b) {
    let x=a;
    let y=b;
    while (y){  //while(a)===while(a!==0)
       let t=y;
       y=x%y;
       x=t;
    }
    console.log(x);
}
GCD(15,5);