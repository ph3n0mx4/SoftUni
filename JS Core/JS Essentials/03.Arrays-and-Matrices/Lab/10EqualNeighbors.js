function solve(matrix) {
    result = 0;
    for (let row = 0; row < matrix.length; row++) {
        for (let col = 0; col < matrix[row].length; col++) {
            for (let row1 = 0; row1 < matrix.length; row1++) {
                for (let col1 = 0; col1 < matrix[row].length; col1++) {
                    let num = Math.sqrt(((row - row1) ** 2) + ((col - col1) ** 2));
                    if (!(row===row1 && col===col1) && num ===1 && matrix[row][col] === matrix[row1][col1]) {
                        result++;
                    }
                }
            }
        }
    }

    console.log(result/2);
}

solve([['2', '3', '4', '7', '0'],
    ['4', '0', '5', '3', '4'],
    ['2', '3', '5', '4', '2'],
    ['9', '8', '7', '5', '4']]
)