function solve(arr) {
    let newArr=[];

    for(let el of arr){

        if(arr.indexOf(el)%2===0){
            newArr.push(el);
        }
    }
    console.log(newArr.join(' '));
}

solve(['20', '30', '40']);