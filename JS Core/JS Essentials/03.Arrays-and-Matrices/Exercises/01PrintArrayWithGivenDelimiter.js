function solve(arr) {
    let delimiter = arr.pop();
    let result = arr.join(`${delimiter}`);
    console.log(result);
}

solve(['One',
    'Two',
    'Three',
    'Four',
    'Five',
    '-']
)