function solve(matrix) {
    let n = matrix.length;
    let result=[0,0];

    for (let i = 0; i < n; i++) {
        result[0]+=matrix[i][i];
        result[1]+=matrix[n-i-1][i];
    }

    console.log(result.join(' '));
}
solve([[20, 40],
    [10, 60]]
)