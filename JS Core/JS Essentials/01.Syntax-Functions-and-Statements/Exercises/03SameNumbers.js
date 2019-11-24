function nums(num) {
    let same =true;
    let sum=0;
    let input =`${num}`
    for (let i = 0; i < input.length; i++) {
        sum+= +input[i];
        if(i>0 && input[i]!==input[i+1] && i<input.length-1)
        {
            same=false;
        }
    }
    console.log(same);
    console.log(sum);
}

nums(2222222);
console.log();
nums(1234);