function solve(matrix) {
    let result = Number.MIN_SAFE_INTEGER;
    for (let row = 0; row <matrix.length ; row++) {
        for (let col = 0; col < matrix[row].length; col++) {
            if(matrix[row][col]>result){
                result=Number(matrix[row][col]);
            }
        }
    }

    console.log(result)
}
solve([[20, 50, 10],
    [8, 33, 145]]
)