function solve(matrix) {
    let result = true;
    let sum=Number.MIN_SAFE_INTEGER;

    for (let row = 0; row < matrix.length; row++) {
        let currentSum=Number.MIN_SAFE_INTEGER;
        for (let col = 0; col < matrix[row].length; col++) {
            currentSum+=matrix[row][col];
        }

        if(row===0){
            sum=currentSum;
        }

        if(sum!==currentSum){
            result=false;
            return console.log(result);
        }
    }

    let newMatrix = matrix.sort((a,b)=>{
        return b.length-a.length;
    })

    for (let col = 0; col < newMatrix[0].length; col++) {
        let currentSum = Number.MIN_SAFE_INTEGER;
        for (let row = 0; row < matrix.length; row++) {
            if(matrix[row][col]!== undefined){
                currentSum+=matrix[row][col];
            }
        }
        if(sum!==currentSum){
            result=false;
            return console.log(result);
        }
    }

    console.log(result);
}
solve([[4, 5, 6],
    [6, 5, 4],
    [5, 5, 5]]
);