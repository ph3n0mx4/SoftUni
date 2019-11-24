function solve(n,k) {
    let arr = [1];
    while (arr.length<n)
    {
        let newNum =0
        for (let i = arr.length; i >=arr.length-k ; i--) {
            if(arr[i]!==undefined){
                newNum+=arr[i];
            }
        }
        arr.push(newNum);
    }

    console.log(arr.join(' '));
}

solve(6, 3);
solve(8, 2);