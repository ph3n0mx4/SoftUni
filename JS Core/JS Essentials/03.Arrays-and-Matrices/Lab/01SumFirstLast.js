function solve(arr) {
    let newArr = arr.map(Number);
    let result= newArr[0]+newArr[newArr.length-1];
    console.log(result);
}

solve(['20', '30', '40']);