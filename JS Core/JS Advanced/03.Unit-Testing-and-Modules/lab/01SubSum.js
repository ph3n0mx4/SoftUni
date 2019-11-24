function solve(arr,startI,endI) {
    if(!Array.isArray(arr)){
        return NaN;
    }

    if(!arr.every(Number)){
        return NaN;
    }

    if(arr.length===0){
        return 0;
    }
    if(startI<0){
        startI=0;
    }
    if(endI>arr.length-1){
        endI=arr.length-1;
    }


    let newArr = arr.slice(startI,endI+1);
    return newArr.reduce((a,b)=>a+b);

}

console.log(solve([10, 'twenty', 30, 40], 0, 2));
console.log(solve([10, 20, 30, 40, 50, 60], 3, 300));