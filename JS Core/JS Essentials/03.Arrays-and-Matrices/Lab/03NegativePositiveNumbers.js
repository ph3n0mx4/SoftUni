function solve(arr) {
    let newArr=[];

    for (let el of arr){
        if(el>=0){
            newArr.push(el);
        }

        else {
            newArr.unshift(el);
        }
    }

    newArr.forEach((value)=> console.log(value));
}
solve([3, -2, 0, -1]);