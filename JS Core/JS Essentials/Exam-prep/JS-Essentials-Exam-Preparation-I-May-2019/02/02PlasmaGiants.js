function solve(arr, arg) {
    let partF = arr.slice(0, arr.length / 2);
    let partS = arr.slice(arr.length / 2, arr.length);
    let sumF = 0;
    let sumS = 0;


    let newArr = arr.slice(0).sort((a, b) => a - b);
    let minN = newArr[0];
    let maxN = newArr[arr.length - 1];

    while (partF.length>0 && partS.length>0){
        sumF+=partF.splice(0,arg).reduce((a,b)=>a*b);
        sumS+=partS.splice(0,arg).reduce((a,b)=>a*b);
    }
    /*if(arg!==0){
        for (let i = 0; i < partF.length; i += arg) {
            let product = 1;
            for (let j = i; j < (i + arg); j++) {
                product *= partF[j];
            }
            sumF += product;
        }
        for (let i = 0; i < partS.length; i += arg) {
            let product = 1;
            for (let j = i; j < (i + arg); j++) {
                product *= partS[j];
            }
            sumS += product;
        }
    }*/

    let rounds = 1;

    while (sumF > maxN && sumS > maxN && minN > 0) {
        sumF -= minN;
        sumS -= minN;
        rounds++;
    }


    let result = ``;
    if (sumF > sumS) {
        result = `First Giant defeated Second Giant with result ${sumF} - ${sumS} in ${rounds} rounds`;
    } else if (sumF < sumS) {
        result = `Second Giant defeated First Giant with result ${sumS} - ${sumF} in ${rounds} rounds`;
    } else if (sumF === sumS) {
        result = `Its a draw ${sumS} - ${sumF}`;
    }

    console.log(result);


}

solve([0,1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12,0], 3)
//solve([3, 3, 3, 4, 5, 6, 7, 8, 9, 10, 5, 4], 2)