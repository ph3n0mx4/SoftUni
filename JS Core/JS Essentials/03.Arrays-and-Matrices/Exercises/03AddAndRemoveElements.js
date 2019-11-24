function solve(input) {
    let arr = [];
    for (let i = 0; i < input.length; i++) {
        arr.push(i+1);
    }
    let result =[];
    for (let i = 0; i < input.length; i++) {
        if(input[i]==='remove'){
            result.pop();
        }

        else {
            result.push(arr[i]);
        }
    }
    //let result =arr.filter(x=>x!='');
    if(result.length>0){
        result.forEach(x=>console.log(x))
    }
    else {
        console.log('Empty');
    }

}
solve(['add',
    'add',
    'remove',
    'add',
    'add']
);