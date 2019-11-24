function solve(arr) {
    let result = arr.sort((a,b)=>{
        if(a.length-b.length===0){
            return a.localeCompare(b);
        }

        return a.length-b.length
    })
    result.forEach(x=>console.log(x));
}
solve(['alpha',
    'beta',
    'gamma']
)