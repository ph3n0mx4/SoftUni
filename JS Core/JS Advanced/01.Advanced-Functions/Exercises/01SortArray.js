function solve(arr, arg) {
    return arr.sort((a,b)=>{
            if(arg===`asc`){
               return  a-b;
            }
            else if(arg===`desc`){
                return b-a;
            }
        });
}

//console.log(solve([14, 7, 17, 6, 8], 'asc'));