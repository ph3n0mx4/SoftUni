function getFibonator(){
    let currentNumber=1;
    let nextNumber=1;
    return ()=>{
        let result =currentNumber;
        currentNumber=nextNumber;
        nextNumber=result+currentNumber;
        return result;
    };
};

let fib = getFibonator();
fib();
fib();
fib();

console.log(fib());

