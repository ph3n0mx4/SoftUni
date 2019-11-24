function solve(input) {
    let maxNum = input[0];
    for (let i = 1; i < input.length; i++) {
        if (input[i] >= maxNum) {
            maxNum = input[i]
        } else {
            input[i] = undefined;
        }
    }
    let newArr = input.filter(x => x != undefined);
    newArr.forEach(x => console.log(x));
}

solve([1,
    3,
    8,
    4,
    10,
    12,
    3,
    2,
    24]
);