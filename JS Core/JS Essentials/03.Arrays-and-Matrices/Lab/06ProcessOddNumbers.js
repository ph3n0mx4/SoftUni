function solve(arr) {
    let newArr = arr.map(x => x * 2);
    let result = [];
    for (let i = 0; i <newArr.length ; i++) {
        if (i % 2 !== 0) {
            result.push(newArr[i]);
        }
    }

    result.reverse();
    console.log(result.join(' '));
}

//solve([10, 15, 20, 25]);
solve([3, 0, 10, 4, 7, 3]);