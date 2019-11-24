function sum(n,m){
    let firstNum = +n;
    let secondNum = +m;
    let result=0;
    
    for (i=firstNum; i<=secondNum; i++){
        result +=i;
    }

    console.log(result);
}