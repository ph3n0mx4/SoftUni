function solve(arr) {
    let result= {};
    for (let i = 0; i < arr.length; i++) {
        let input = arr[i].split(' <-> ');
        if(!result[input[0]]){
            result[input[0]]=0;
        }
        result[input[0]]+=Number(input[1]);
    }

    for (var obj in result)
    {
        console.log(`${obj} : ${result[obj]}`);
    }
}

solve(['Sofia <-> 1200000',
'Montana <-> 20000',
'New York <-> 10000000',
'Washington <-> 2345000',
'Las Vegas <-> 1000000']
);