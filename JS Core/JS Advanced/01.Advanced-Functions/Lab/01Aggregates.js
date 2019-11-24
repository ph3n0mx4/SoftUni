function solve(arr) {
    console.log(`Sum = ${arr.reduce((a,b)=>a+b)}`);
    console.log(`Min = ${arr.reduce((a,b)=>Math.min(a,b))}`);
    console.log(`Max = ${arr.reduce((a,b)=>Math.max(a,b))}`);
    console.log(`Product = ${arr.reduce((a,b)=>a*b)}`);
    console.log(`Join = ${arr.join(``)}`);
}
solve([2, 3, 10, 5]);

/**Sum = 20
 Min = 2
 Max = 10
 Product = 300
 Join = 23105
**/